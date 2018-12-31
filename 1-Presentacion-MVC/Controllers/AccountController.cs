using System;
using System.Web.Mvc;
using System.Web.Security;
using _1_Presentacion_MVC.Models;
using _5_InterfazComun.Constantes;

namespace _1_Presentacion_MVC.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", GlobalResources.msgPasswordIncorrect);
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MembershipUser NewUser = Membership.CreateUser(model.UserName, model.Password);

                    FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Registration Error", "Registration error: " + e.StatusCode.ToString());
                }
            }

            return View(model);
        }

        public ActionResult ResetPassword(Enumeradores.ManageMessageId? message)
        {
            if (message != null)
            {
                ViewBag.StatusMessage = "Your password has been changed";
            }

            ViewBag.ReturnUrl = Url.Action("ResetPassword");

            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(LocalPassword model)
        {
            ViewBag.ReturnUrl = Url.Action("ResetPassword");

            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = Membership.Provider.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ResetPassword", new { message = Enumeradores.ManageMessageId.ChangePasswordSuccess });
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid");
                }
            }

            return View(model);
        }
    }
}
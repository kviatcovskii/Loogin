using CadastroUsuarioViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;
using WebApplication11.ViewsModels;
using WebApplication11.utils;
using System.Security.Claims;

namespace WebApplication11.Controllers
{
    public class AutenticacaoController : Controller


    {
        private UsuariosContext db = new UsuariosContext();
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewsModels viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (db.Usuarios.Count(u => u.Login == viewModel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já existe");
                return View(viewModel);
            }




            Usuario novoUsuario = new Usuario
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
            };
            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizado com sucesso";
            return RedirectToAction("index", "home");
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewsModels = new LoginViewsModels
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewsModels);
        }

        [HttpPost]
        public ActionResult Login(LoginViewsModels viewsModels)
        {
            if (!ModelState.IsValid)
            {
                return View(viewsModels);
            };

            var usuario = db.Usuarios.FirstOrDefault(
                u => u.Login == viewsModels.Login);


            if (usuario == null)
            {
                ModelState.AddModelError("login", "falhou na missao");
                return View(viewsModels);
            }

            if (usuario.Senha != Hash.GerarHash(viewsModels.Senha))
            {
                ModelState.AddModelError("Senha", "Login ou senha incorreto");
                return View(viewsModels);
            }

            var identity = new ClaimsIdentity(new[]

                {
                new Claim("Login",usuario.Login)
                }, "ApplicationCookie"
                );

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewsModels.UrlRetorno) || Url.IsLocalUrl(viewsModels.UrlRetorno))
            {
                return Redirect(viewModel.UrlRetorno);
            }
            else
            {
                return RedirectToAction("index", "painel");
            }
        }
            public ActionResult Logout()
            {
                Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
                return RedirectToAction("index", "home");
            }
        
    }
}

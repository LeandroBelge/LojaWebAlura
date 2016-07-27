﻿using LojaWeb.DAO;
using LojaWeb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        private UsuariosDAO dao;

        public UsuariosController(UsuariosDAO Dao)
        {
            this.dao = Dao;
        }

        public ActionResult Index()
        {
            IList<Usuario> usuarios = this.dao.Lista();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Usuario usuario)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Usuario usuario = this.dao.BuscaPorId(id);
            return View(usuario);
        }

        public ActionResult Atualiza(Usuario usuario)
        {
            return RedirectToAction("Index");
        }

    }
}

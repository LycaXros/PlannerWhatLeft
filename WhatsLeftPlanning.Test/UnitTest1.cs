using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataEntity.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhatLeftPlanning.MockServices;
using WhatLeftPlanning.Services;

namespace WhatsLeftPlanning.Test
{
    [TestClass]
    public class UnitTest1
    {
        IUnidadTrabajo _uow;
        

        [TestInitialize]
        public void SetUp()
        {
            _uow = new MockUnidadTrabajo(PrepareData());
        }

        private Dictionary<Type, object> PrepareData()
        {
            Dictionary<Type, object> context = new Dictionary<Type, object>();

            var rol1 = new Rol() { ID = 1, Nombre = "Administrador" };
            var rol2 = new Rol() { ID = 2, Nombre = "Lider" };
            var rol3 = new Rol() { ID = 3, Nombre="Normal"};

            var user1 = new Usuario() { ID = 1, Nombre = "Jesus", Apellido = "Dicent", Nick = "Admin", Contraseña = "VhKWfY5q9CpRTSqbwSpe6A==" };
            rol1.Usuarios.Add(user1);
            rol2.Usuarios.Add(user1);
            rol3.Usuarios.Add(user1);

            user1.Roles.Add(rol1);
            user1.Roles.Add(rol2);
            user1.Roles.Add(rol3);

            var tipo1 = new Tipo_Tarea() { ID = 1, Nombre = "Diaria" };
            var tipo2 = new Tipo_Tarea() { ID = 2, Nombre = "Tempoal" };

            var users = new List<Usuario>() { user1};

            context.Add(typeof(Usuario), users);
            context.Add(typeof(Rol), new List<Rol> { rol1, rol2, rol3});
            context.Add(typeof(Tipo_Tarea), new List<Tipo_Tarea> { tipo1, tipo2});
            context.Add(typeof(UsuarioGrupo), new List<UsuarioGrupo>());
            context.Add(typeof(Grupo), new List<Grupo>());
            context.Add(typeof(Tarea), new List<Tarea>());
            context.Add(typeof(Tarea_Detalle), new List<Tarea_Detalle>());

            return context;
        }

        [TestMethod]
        public async Task ValidaContraseña()
        {
            
            var usuario = (await _uow.Usuarios.GetAll()).ToList().First(x => x.Nick.Equals("Admin"));
            var contra = DataEntity.DataTransform.Encriptador.Desencriptar(usuario.Contraseña);
            if(StringAssert.Equals("123456Pass", contra))
            {
                Console.WriteLine("Passed");
            }

            bool validUser = await _uow.Usuarios.ValidarCredencialesAsync("Admin", "123456pass");
            Assert.AreEqual(true, validUser);
        }

        [TestMethod]
        public void CantidadTipos()
        {
            var tipos =  _uow.Tareas.ObtenerTipos();

            Assert.AreEqual(2, tipos.Count());
        }
    }
}

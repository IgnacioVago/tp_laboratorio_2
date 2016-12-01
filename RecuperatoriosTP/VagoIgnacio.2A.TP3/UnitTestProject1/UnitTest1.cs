using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarDocumentoArgentino()
        {
            Random random = new Random();
            int dniNuevo = random.Next(1, 90000000);

            Alumno a1 = new Alumno(1990, "Jorge", "Lopez", dniNuevo.ToString(), Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);

            Assert.AreEqual(a1.DNI, dniNuevo);
        }
        
        [TestMethod]
        public void ValidarDocumentoExtranjero()
        {
            Random random = new Random();
            int dniNuevo = random.Next(90000000, 100000000);

            Alumno a1 = new Alumno(1990, "Jorge", "Lopez", dniNuevo.ToString(), Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit);

            Assert.AreEqual(a1.DNI, dniNuevo);
        }
        
        [TestMethod]
        public void GimnasioNoInstanciado()
        {
            Gimnasio g1 = new Gimnasio();

            Assert.AreNotEqual(null, g1.Instructores);
            Assert.AreNotEqual(null, g1.Alumnos);

            Assert.IsNotNull(g1);
        }
        
        [TestMethod]
        public void AlumnoNoInstanciado()
        {
            Alumno a1 = new Alumno(1990, "Jorge", "Lopez", "40000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit);

            Assert.AreNotEqual(null, a1.Nombre);
            Assert.AreNotEqual(null, a1.Apellido);
            Assert.AreNotEqual(null, a1.DNI);
            Assert.AreNotEqual(null, a1.Nacionalidad);

            Assert.IsNotNull(a1);
        }
        
        [TestMethod]
        public void AlumnoRepetido()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Jorge", "Lopez", "40000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);
                Alumno a2 = new Alumno(2, "Jorge", "Lopez", "40000000", Persona.ENacionalidad.Argentino, Gimnasio.EClases.Pilates, Alumno.EEstadoCuenta.AlDia);

                Gimnasio gimnasioPrueba = new Gimnasio();

                gimnasioPrueba += a1;
                gimnasioPrueba += a2;

                Assert.Fail("Alumno repetido");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
            }
        }
        
        [TestMethod]
        public void InstructorNoInstanciado()
        {
            Instructor i = new Instructor(1990, "Jorge", "Lopez", "40000000", Persona.ENacionalidad.Argentino);

            Assert.AreNotEqual(null, i.Nombre);
            Assert.AreNotEqual(null, i.Apellido);
            Assert.AreNotEqual(null, i.DNI);
            Assert.AreNotEqual(null, i.Nacionalidad);

            Assert.IsNotNull(i);
        }
        
    }
}

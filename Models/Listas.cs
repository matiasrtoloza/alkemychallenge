using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alkemy.Models;

namespace Alkemy.App_Code
{
    public static class Global
    {  
        static List<Profesor> _listaDeProfesores = new List<Profesor>() {
                new Profesor { Nombre = "Pedro", Apellido= "Perez", Id = 1, Estado = true, Dni =241233},
                new Profesor { Nombre = "Mariana", Apellido= "Lopez", Id = 2, Estado =false, Dni =252423},
                new Profesor { Nombre = "Ana", Apellido= "Laura", Id = 3, Estado = false, Dni =842325},
                new Profesor { Nombre = "Marcos", Apellido= "Rodriguez", Id = 4, Estado = true, Dni =24124}
            };

        public static List<Profesor> ListaDeProfesores
        {
            get
            {
                return _listaDeProfesores;
            }
            set
            {
                _listaDeProfesores = value;
            }
        }

        static List<Materia> _listaDeMaterias = new List<Materia>() {
                new Materia { NombreMateria = "Matematica", IdProfesor= 1, Id = 1, Horario = 14, CupMax =10},
                new Materia { NombreMateria = "Ingles", IdProfesor= 2, Id = 2, Horario = 16, CupMax =10},
                new Materia { NombreMateria = "Fisica", IdProfesor= 3, Id = 3, Horario = 18, CupMax =15},
                new Materia { NombreMateria = "Historia", IdProfesor= 4, Id = 4, Horario = 20, CupMax =10},
            };

        public static List<Materia> ListaDeMaterias
        {
            get
            {
                return _listaDeMaterias;
            }
            set
            {
                _listaDeMaterias = value;
            }
        }
    }
}
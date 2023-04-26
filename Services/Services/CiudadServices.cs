using infraestructure.Models;
using infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services.Services
{
    public class CiudadService
    {
        private CiudadRepository repositoryCiudad;

        public CiudadService(string connectionString)
        {
            this.repositoryCiudad = new CiudadRepository(connectionString);
        }
        public CiudadModel consultarCiudad(int idciudad)
        {
            return repositoryCiudad.consultarCiudad(idciudad);
        }

        public string insertarCiudad(CiudadModel ciudad)
        {
            return validarDatosCiudad(ciudad) ? repositoryCiudad.insertarCiudad(ciudad) : throw new Exception("Error en la validacion");
        }

        public string eliminarCiudad(int idciudad)
        {
            return repositoryCiudad.eliminarCiudad(idciudad);
        }
        public string modificarCiudad(CiudadModel ciudad, int idciudad)
        {
            if (repositoryCiudad.consultarCiudad(idciudad) != null)
                return validarDatosCiudad(ciudad) ?
                    repositoryCiudad.modificarCiudad(ciudad, idciudad) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta persona";
        }


        private bool validarDatosCiudad(CiudadModel ciudad)
        {
            //if (ciudad.ciudad.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }
    }
}

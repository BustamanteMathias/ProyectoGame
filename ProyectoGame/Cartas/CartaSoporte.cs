using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{ 
    public class CartaSoporte
    {
        private int id;
        private float dFisica;
        private float dMagico;
        private float vida;
        private string descipcion;
        private string nombre;
        private EClase clase;

        public int ID { get { return this.id; } }
        public float DefensaMagica { get { return this.dMagico; } }
        public float DefensaFisica { get { return this.dFisica; } }
        public float Vida { get { return this.vida; } }
        public string Nombre { get { return this.nombre; } }

        public CartaSoporte(int id, string nombre, string descripcion, float vida, float dFisica, float dMagico)
        {
            this.id = id;
            this.nombre = nombre;
            this.clase = EClase.Soporte;
            this.descipcion = descripcion;

            this.vida = vida;
            this.dFisica = dFisica;
            this.dMagico = dMagico;
        }

        public string Mostrar()
        {
            return string.Format("TIPO: SOPORTE\nID: {0}\nNombre: {1}\nDescripcion: {2}\n\nVida: {3}\nDefensa Fisico: {4}\nDefensa Magica: {5}\n--------------------------------------------------------------\n", this.id, this.nombre, this.descipcion, this.vida, this.dFisica, this.dMagico);
        }

        public static implicit operator string(CartaSoporte c)
        {
            return c.Mostrar();
        }
    }
}

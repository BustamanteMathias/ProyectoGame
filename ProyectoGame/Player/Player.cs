using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{
    public class Player
    {
        private string nombre;

        private float vida;
        private float dFisica;
        private float dMagica;

        private NPC_Guitarra NPC_GUITARRISTA_1;
        private NPC_Guitarra NPC_GUITARRISTA_2;
        private NPC_Bajo     NPC_BAJISTA;
        private NPC_Bateria  NPC_BATERISTA;
        private NPC_Voz      NPC_VOZ;

        private CartaSoporte SLOT_SOPORTE_1;
        private CartaSoporte SLOT_SOPORTE_2;
        private CartaSoporte SLOT_SOPORTE_3;
        private CartaSoporte SLOT_SOPORTE_4;
        private CartaSoporte SLOT_SOPORTE_5;

        #region PROPIEDAD GET PARA SABER SI EXISTE NPC
        public bool ExisteNPC_Guitarra1
        {
            get
            {
                if (this.NPC_GUITARRISTA_1 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ExisteNPC_Guitarra2
        {
            get
            {
                if (this.NPC_GUITARRISTA_2 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ExisteNPC_Bajo
        {
            get
            {
                if (this.NPC_BAJISTA != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ExisteNPC_Bateria
        {
            get
            {
                if (this.NPC_BATERISTA != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ExisteNPC_Voz
        {
            get
            {
                if (this.NPC_VOZ != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
        public NPC_Guitarra GetNPC_Guitarra1 { get { return this.NPC_GUITARRISTA_1; } set { this.NPC_GUITARRISTA_1 = value; } }
        public NPC_Guitarra GetNPC_Guitarra2 { get { return this.NPC_GUITARRISTA_2; } set { this.NPC_GUITARRISTA_2 = value; } }
        public NPC_Bajo GetNPC_Bajo { get { return this.NPC_BAJISTA; } set { this.NPC_BAJISTA = value; } }
        public NPC_Bateria GetNPC_Bateria { get { return this.NPC_BATERISTA; } set { this.NPC_BATERISTA = value; } }
        public NPC_Voz GetNPC_Voz { get { return this.NPC_VOZ; } set { this.NPC_VOZ = value; } }
        public float Vida { get { return this.vida; } set { this.vida = value; } }
        public float DefensaFisica { get { return this.dFisica; } set { this.dFisica = value; } }
        public float DefensaMagica { get { return this.dMagica; } set { this.dMagica = value; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }

        #region CONSTRUCTORES
        public Player()
        {
            this.nombre             = "DEFAULT";
            this.vida               = 10000;
            this.dFisica            = 1000;
            this.dMagica            = 1000;

            this.SLOT_SOPORTE_1     = null; // SLOT 1
            this.SLOT_SOPORTE_2     = null; // SLOT 2
            this.SLOT_SOPORTE_3     = null; // SLOT 3
            this.SLOT_SOPORTE_4     = null; // SLOT 4
            this.SLOT_SOPORTE_5     = null; // SLOT 5

            this.NPC_GUITARRISTA_1  = null; // SLOT 6
            this.NPC_GUITARRISTA_2  = null; // SLOT 7
            this.NPC_BAJISTA        = null; // SLOT 8
            this.NPC_BATERISTA      = null; // SLOT 9
            this.NPC_VOZ            = null; // SLOT 10
        }

        public Player(string nombre, float vida, float dFisica, float dMagica) : this()
        {
            this.nombre = nombre;
            this.vida = vida;
            this.dFisica = dFisica;
            this.dMagica = dMagica;
        }
        #endregion

        #region SOBRECARGAS
        public static Player operator +(Player p, CartaSoporte cs)
        {
            if (cs != null)
            {
                if (p.SLOT_SOPORTE_1 == null)
                {
                    p.SLOT_SOPORTE_1 = cs;

                    p.Vida += cs.Vida;
                    p.DefensaFisica+= cs.DefensaFisica;
                    p.DefensaMagica += cs.DefensaMagica;

                    Console.WriteLine("Se agrego carta al slot CARTA SOPORTE 1");
                }
                else if (p.SLOT_SOPORTE_2 == null)
                {
                    p.SLOT_SOPORTE_2 = cs;

                    p.Vida += cs.Vida;
                    p.DefensaFisica += cs.DefensaFisica;
                    p.DefensaMagica += cs.DefensaMagica;

                    Console.WriteLine("Se agrego carta al slot CARTA SOPORTE 2");
                }
                else if (p.SLOT_SOPORTE_3 == null)
                {
                    p.SLOT_SOPORTE_3 = cs;

                    p.Vida += cs.Vida;
                    p.DefensaFisica += cs.DefensaFisica;
                    p.DefensaMagica += cs.DefensaMagica;

                    Console.WriteLine("Se agrego carta al slot CARTA SOPORTE 3");
                }
                else if (p.SLOT_SOPORTE_4 == null)
                {
                    p.SLOT_SOPORTE_4 = cs;

                    p.Vida += cs.Vida;
                    p.DefensaFisica += cs.DefensaFisica;
                    p.DefensaMagica += cs.DefensaMagica;

                    Console.WriteLine("Se agrego carta al slot CARTA SOPORTE 4");
                }
                else if (p.SLOT_SOPORTE_5 == null)
                {
                    p.SLOT_SOPORTE_5 = cs;

                    p.Vida += cs.Vida;
                    p.DefensaFisica += cs.DefensaFisica;
                    p.DefensaMagica += cs.DefensaMagica;

                    Console.WriteLine("Se agrego carta al slot CARTA SOPORTE 5");
                }
                else
                {
                    Console.WriteLine("Error. No hay mas espacios para cartas soportes");
                }
            }
            return p;
        }

        public static Player operator +(Player p, NPC npc)
        {
            if (npc != null)
            {
                if (npc is NPC_Bajo)
                {
                    if (p.NPC_BAJISTA == null)
                    {
                        p.NPC_BAJISTA = (NPC_Bajo)npc;
                    }
                    else
                    {
                        Console.WriteLine("Error. SLOT de bajista ya ocupado.");
                    }
                }
                else if (npc is NPC_Guitarra)
                {
                    if (p.NPC_GUITARRISTA_1 == null)
                    {
                        p.NPC_GUITARRISTA_1 = (NPC_Guitarra)npc;
                    }
                    else if (p.NPC_GUITARRISTA_2 == null)
                    {
                        p.NPC_GUITARRISTA_2 = (NPC_Guitarra)npc;
                    }
                    else
                    {
                        Console.WriteLine("Error. SLOT de guitarristas ya ocupado.");
                    }
                }
                else if (npc is NPC_Bateria)
                {
                    if (p.NPC_BATERISTA == null)
                    {
                        p.NPC_BATERISTA = (NPC_Bateria)npc;
                    }
                    else
                    {
                        Console.WriteLine("Error. SLOT de bateria ya ocupado.");
                    }
                }
                else if (npc is NPC_Voz)
                {
                    if (p.NPC_VOZ == null)
                    {
                        p.NPC_VOZ = (NPC_Voz)npc;
                    }
                    else
                    {
                        Console.WriteLine("Error. SLOT de bateria ya ocupado.");
                    }
                }
                else
                {
                    Console.WriteLine("Error. Clase de NPC invalido.");
                }

            }

            return p;
        }

        public static Player operator -(Player p, int SLOT)
        {
            switch (SLOT)
            {
                case 1:
                    p.SLOT_SOPORTE_1 = null;
                    Console.WriteLine("Se removio SLOT 1. Soporte 1.");
                    break;
                case 2:
                    p.SLOT_SOPORTE_2 = null;
                    Console.WriteLine("Se removio SLOT 2. Soporte 2.");
                    break;
                case 3:
                    p.SLOT_SOPORTE_3 = null;
                    Console.WriteLine("Se removio SLOT 3. Soporte 3.");
                    break;
                case 4:
                    p.SLOT_SOPORTE_4 = null;
                    Console.WriteLine("Se removio SLOT 4. Soporte 4.");
                    break;
                case 5:
                    p.SLOT_SOPORTE_5 = null;
                    Console.WriteLine("Se removio SLOT 5. Soporte 5.");
                    break;
                case 6:
                    p.NPC_GUITARRISTA_1 = null;
                    Console.WriteLine("Se removio SLOT 6. Guitarrista 1.");
                    break;
                case 7:
                    p.NPC_GUITARRISTA_2 = null;
                    Console.WriteLine("Se removio SLOT 7. Guitarrista 2.");
                    break;
                case 8:
                    p.NPC_BAJISTA = null;
                    Console.WriteLine("Se removio SLOT 8. Bajista.");
                    break;
                case 9:
                    p.NPC_BATERISTA = null;
                    Console.WriteLine("Se removio SLOT 9. Baterista.");
                    break;
                case 10:
                    p.NPC_VOZ = null;
                    Console.WriteLine("Se removio SLOT 10. Voz.");
                    break;
                default:
                    Console.WriteLine("Error. SLOT invalido.");
                    break;
            }
            return p;
        } 
        #endregion

        public static implicit operator string(Player p)
        {
            StringBuilder rtn = new StringBuilder();
            rtn.AppendFormat("--------------------------------------> {0}\n", p.nombre);
            rtn.AppendFormat("PUNTOS DE VIDA: {0}\n", p.vida);
            rtn.AppendFormat("DEFENSA FISICA: {0}\n", p.dFisica);
            rtn.AppendFormat("DEFENSA MAGICA: {0}\n\n", p.dMagica);

            //NIVEL Y EXPERIENCIA NO LO PONGO PORQUE NO HACE FALTA TODAVIA, ES SOLO PARA TESTS

            if (p.NPC_GUITARRISTA_1 != null)
            {
                rtn.AppendFormat("-----> Guitarrista 1: {0}\n", p.NPC_GUITARRISTA_1.Nombre);
                rtn.AppendFormat("PUNTOS DE VIDA: {0}\n", p.NPC_GUITARRISTA_1.Vida);
                rtn.AppendFormat("DEFENSA FISICA: {0}\n", p.NPC_GUITARRISTA_1.DefensaFisica);
                rtn.AppendFormat("DEFENSA MAGICA: {0}\n", p.NPC_GUITARRISTA_1.DefensaMagica);
                rtn.AppendFormat("ATAQUE  FISICO: {0}\n", p.NPC_GUITARRISTA_1.AtaqueFisico);
                rtn.AppendFormat("ATAQUE  MAGICO: {0}\n\n", p.NPC_GUITARRISTA_1.AtaqueMagico);
            }

            if (p.NPC_GUITARRISTA_2 != null)
            {
                rtn.AppendFormat("-----> Guitarrista 2: {0}\n", p.NPC_GUITARRISTA_2.Nombre);
                rtn.AppendFormat("PUNTOS DE VIDA: {0}\n", p.NPC_GUITARRISTA_2.Vida);
                rtn.AppendFormat("DEFENSA FISICA: {0}\n", p.NPC_GUITARRISTA_2.DefensaFisica);
                rtn.AppendFormat("DEFENSA MAGICA: {0}\n", p.NPC_GUITARRISTA_2.DefensaMagica);
                rtn.AppendFormat("ATAQUE  FISICO: {0}\n", p.NPC_GUITARRISTA_2.AtaqueFisico);
                rtn.AppendFormat("ATAQUE  MAGICO: {0}\n\n", p.NPC_GUITARRISTA_2.AtaqueMagico);
            }

            if (p.NPC_BAJISTA != null)
            {
                rtn.AppendFormat("-----> Bajista: {0}\n", p.NPC_BAJISTA.Nombre);
                rtn.AppendFormat("PUNTOS DE VIDA: {0}\n", p.NPC_BAJISTA.Vida);
                rtn.AppendFormat("DEFENSA FISICA: {0}\n", p.NPC_BAJISTA.DefensaFisica);
                rtn.AppendFormat("DEFENSA MAGICA: {0}\n", p.NPC_BAJISTA.DefensaMagica);
                rtn.AppendFormat("ATAQUE  FISICO: {0}\n", p.NPC_BAJISTA.AtaqueFisico);
                rtn.AppendFormat("ATAQUE  MAGICO: {0}\n\n", p.NPC_BAJISTA.AtaqueMagico);
            }

            if (p.NPC_BATERISTA != null)
            {
                rtn.AppendFormat("-----> Baterista: {0}\n", p.NPC_BATERISTA.Nombre);
                rtn.AppendFormat("PUNTOS DE VIDA: {0}\n", p.NPC_BATERISTA.Vida);
                rtn.AppendFormat("DEFENSA FISICA: {0}\n", p.NPC_BATERISTA.DefensaFisica);
                rtn.AppendFormat("DEFENSA MAGICA: {0}\n", p.NPC_BATERISTA.DefensaMagica);
                rtn.AppendFormat("ATAQUE  FISICO: {0}\n", p.NPC_BATERISTA.AtaqueFisico);
                rtn.AppendFormat("ATAQUE  MAGICO: {0}\n\n", p.NPC_BATERISTA.AtaqueMagico);
            }

            if (p.NPC_VOZ != null)
            {
                rtn.AppendFormat("-----> Voz: {0}\n", p.NPC_VOZ.Nombre);
                rtn.AppendFormat("PUNTOS DE VIDA: {0}\n", p.NPC_VOZ.Vida);
                rtn.AppendFormat("DEFENSA FISICA: {0}\n", p.NPC_VOZ.DefensaFisica);
                rtn.AppendFormat("DEFENSA MAGICA: {0}\n", p.NPC_VOZ.DefensaMagica);
                rtn.AppendFormat("ATAQUE  FISICO: {0}\n", p.NPC_VOZ.AtaqueFisico);
                rtn.AppendFormat("ATAQUE  MAGICO: {0}\n", p.NPC_VOZ.AtaqueMagico);
            }
            
            return rtn.ToString();
        }
    }
}

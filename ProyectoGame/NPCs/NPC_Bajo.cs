using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{
    public class NPC_Bajo : NPC
    {
        private EClase clase;
        private Carta CARTA_1;
        private Carta CARTA_2;
        private Carta CARTA_3;

        public NPC_Bajo(int id, string nombre, string descripcion, float vida, int nivel, double experiencia, float aFisico, float aMagico, float dFisica, float dMagica) : base(id, nombre, descripcion, vida, nivel, experiencia, aFisico, aMagico, dFisica, dMagica)
        {
            this.CARTA_1 = null;
            this.CARTA_2 = null;
            this.CARTA_3 = null;
            this.clase = EClase.Bajo;
        }

        public static NPC_Bajo operator +(NPC_Bajo NPC, Carta c)
        {
            
            if (c.Clase == EClase.Bajo)
            {
                if (NPC.CARTA_1 == null)
                {
                    NPC.CARTA_1 = c;
                    NPC.AtaqueFisico += c.AtaqueFisico;
                    NPC.AtaqueMagico += c.AtaqueMagico;
                    NPC.DefensaFisica += c.DefensaFisica;
                    NPC.DefensaMagica += c.DefensaMagica;
                    Console.WriteLine("Se agregar carta en SLOT: 1");
                }
                else if (NPC.CARTA_2 == null)
                {
                    NPC.CARTA_2 = c;
                    NPC.AtaqueFisico += c.AtaqueFisico;
                    NPC.AtaqueMagico += c.AtaqueMagico;
                    NPC.DefensaFisica += c.DefensaFisica;
                    NPC.DefensaMagica += c.DefensaMagica;
                    Console.WriteLine("Se agregar carta en SLOT: 2");
                }
                else if (NPC.CARTA_3 == null)
                {
                    NPC.CARTA_3 = c;
                    NPC.AtaqueFisico += c.AtaqueFisico;
                    NPC.AtaqueMagico += c.AtaqueMagico;
                    NPC.DefensaFisica += c.DefensaFisica;
                    NPC.DefensaMagica += c.DefensaMagica;
                    Console.WriteLine("Se agregar carta en SLOT: 3");
                }
                else
                {
                    Console.WriteLine("Error. No hay mas slot disponibles");
                }
            }
            else
            {
                Console.WriteLine("Error. No se puede agregar porque la carta no es del mismo tipo que es NPC");
            }
            return NPC;
        }

        public static NPC_Bajo operator -(NPC_Bajo NPC, int SLOT)
        {
            switch(SLOT)
            {
                case 1:
                    if(NPC.CARTA_1 != null)
                    {
                        NPC.AtaqueFisico -= NPC.CARTA_1.AtaqueFisico;
                        NPC.AtaqueMagico -= NPC.CARTA_1.AtaqueMagico;
                        NPC.DefensaFisica -= NPC.CARTA_1.DefensaFisica;
                        NPC.DefensaMagica -= NPC.CARTA_1.DefensaMagica;

                        NPC.CARTA_1 = null;

                        Console.WriteLine("Se elimino carta en SLOT: 1");
                    }
                    else
                    {
                        Console.WriteLine("Nada que eliminar. SLOT vacio");
                    }

                    break;
                case 2:
                    if (NPC.CARTA_2 != null)
                    {
                        NPC.AtaqueFisico -= NPC.CARTA_2.AtaqueFisico;
                        NPC.AtaqueMagico -= NPC.CARTA_2.AtaqueMagico;
                        NPC.DefensaFisica -= NPC.CARTA_2.DefensaFisica;
                        NPC.DefensaMagica -= NPC.CARTA_2.DefensaMagica;

                        NPC.CARTA_2 = null;

                        Console.WriteLine("Se elimino carta en SLOT: 2");
                    }
                    else
                    {
                        Console.WriteLine("Nada que eliminar. SLOT vacio");
                    }

                    break;
                case 3:
                    if (NPC.CARTA_3 != null)
                    {
                        NPC.AtaqueFisico -= NPC.CARTA_3.AtaqueFisico;
                        NPC.AtaqueMagico -= NPC.CARTA_3.AtaqueMagico;
                        NPC.DefensaFisica -= NPC.CARTA_3.DefensaFisica;
                        NPC.DefensaMagica -= NPC.CARTA_3.DefensaMagica;

                        NPC.CARTA_3 = null;

                        Console.WriteLine("Se elimino carta en SLOT: 3");
                    }
                    else
                    {
                        Console.WriteLine("Nada que eliminar. SLOT vacio");
                    }

                    break;
                default:
                    Console.WriteLine("Error. Slot incorrecto");
                    break;
            }
            return NPC;
        }
    }
}

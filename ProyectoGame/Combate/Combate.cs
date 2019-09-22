using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{
    public static class Combate
    {
        public static bool Player_vs_Player(Player p1, Player p2, out string infoCombate)
        {
            bool rtn = false;
            infoCombate = "";

            bool finDeTurno = false;

            bool flagGuitarra1 = true;
            bool flagGuitarra2 = true;
            bool flagBajo = true;
            bool flagBateria = true;
            bool flagVoz = true;

            Random rnd = new Random(); //CACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            bool laconchadetumadre = true;

            /* 
             LOGICA DE COMBATE:

             Combate entre Player1 vs Player2 (O viceversa intercambiando los player en la llamada de funcion).
             El algoritmo siempre es Player 1 atacando y Player 2 defendiendo.

                Elige un numero random entre 1 y 5 para elegir con que NPC atacar.
                Una vez elija con que NPC atacar, pregunta si existe. (En el caso de no poder atacar con ese NPC coloca una bandera en FALSE).
                Caso de no poder atacar con ninguno (No teniendo ningun NPC) todas sus banderas estar�n en FALSE y romperia el ciclo Do While finalizando el turno.
                Caso de ser TRUE la existencia de ese NPC procede a elejir un numero random entre 1 y 2. Con este random logra hacer el ATAQUE FISICO o ATAQUE MAGICO.

             -> Sabiendo con que NPC atacar, elijiendo de que tipo va a ser el ataque (ATAQUE FISICO/ATAQUE MAGICO), ya esta listo para el combate.

                Elije un random del 1 al 5 para saber a que enemigo atacar, si existe lo ataca a sus puntos de defensa del tipo de ataque.
                Al resistir el NPC ese ataque sigue defendiendo, al romperse los puntos de defensa el ataque golpea directamente a sus puntos de vida.
                Si el NPC muere es sacado del combate. Si el ataque se da en el SLOT de un NPC ya muerto el ataque va directamente a los puntos de defensa del Player 2.
                Si el Player 2 no tiene defensas sobre ese tipo golpea directamente a los PUNTOS DE SALUD hasta dejarlo fuera de combate.

            Basicamente es eso resumido. Version 1.0
            Se pulir� m�s con el tiempo, apicando random de efectividad, golpes criticos, skills, etc.
             */

            do
            {
                switch (rnd.Next(1, 6))
                {
                    case 1:
                        if (p1.ExisteNPC_Guitarra1)
                        {
                            #region PLAYER1 ATACA CON GUITARRISTA1 A PLAYER2
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    // ATAQUE FISICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AF A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaFisica = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de atauqe fisico a la DF de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AF A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaFisica = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AF A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaFisica = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AF A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaFisica = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AF A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaFisica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaFisica = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }
                                    break;

                                case 2:
                                    // ATAQUE MAGICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AM A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaMagica = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AM A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaMagica = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AM A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaMagica = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AM A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaMagica = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AM A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaMagica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaMagica = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra1.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra1.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra1.Nombre + " y causo " + p1.GetNPC_Guitarra1.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }

                                    break;
                            }
                            rtn = true;
                            #endregion
                        }
                        else
                        {
                            flagGuitarra1 = false;
                        }
                        break;

                    case 2:
                        if (p1.ExisteNPC_Guitarra2)
                        {
                            #region PLAYER1 ATACA CON GUITARRISTA2 A PLAYER2
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    // ATAQUE FISICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AF A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaFisica = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de atauqe fisico a la DF de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AF A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaFisica = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra1.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AF A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaFisica = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AF A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaFisica = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AF A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaFisica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaFisica = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Guitarra2.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }
                                    break;

                                case 2:
                                    // ATAQUE MAGICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AM A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaMagica = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AM A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaMagica = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AM A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaMagica = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AM A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaMagica = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AM A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaMagica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaMagica = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Guitarra2.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Guitarra2.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Guitarra2.Nombre + " y causo " + p1.GetNPC_Guitarra2.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }

                                    break;
                            }
                            rtn = true;
                            #endregion
                        }
                        else
                        {
                            flagGuitarra2 = false;
                        }
                        break;
                    case 3:
                        if (p1.ExisteNPC_Bajo)
                        {
                            #region PLAYER1 ATACA CON BAJO A PLAYER2
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    // ATAQUE FISICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AF A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaFisica = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de atauqe fisico a la DF de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AF A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaFisica = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AF A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaFisica = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AF A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaFisica = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AF A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaFisica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaFisica = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bajo.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }
                                    break;

                                case 2:
                                    // ATAQUE MAGICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AM A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaMagica = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AM A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaMagica = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AM A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaMagica = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AM A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaMagica = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AM A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaMagica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaMagica = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bajo.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bajo.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bajo.Nombre + " y causo " + p1.GetNPC_Bajo.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }

                                    break;
                            }
                            rtn = true;
                            #endregion
                        }
                        else
                        {
                            flagBajo = false;
                        }
                        break;
                    case 4:
                        if (p1.ExisteNPC_Bateria)
                        {
                            #region PLAYER1 ATACA CON BATERIA A PLAYER2
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    // ATAQUE FISICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AF A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaFisica = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de atauqe fisico a la DF de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AF A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaFisica = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AF A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaFisica = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AF A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaFisica = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AF A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaFisica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaFisica = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Bateria.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }
                                    break;

                                case 2:
                                    // ATAQUE MAGICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AM A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaMagica = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AM A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaMagica = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AM A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaMagica = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AM A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaMagica = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AM A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaMagica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaMagica = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Bateria.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Bateria.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Bateria.Nombre + " y causo " + p1.GetNPC_Bateria.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }

                                    break;
                            }
                            rtn = true;
                            #endregion
                        }
                        else
                        {
                            flagBateria = false;
                        }
                        break;
                    case 5:
                        if (p1.ExisteNPC_Voz)
                        {
                            #region PLAYER1 ATACA CON VOZ A PLAYER2
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    // ATAQUE FISICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AF A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaFisica = p2.GetNPC_Guitarra1.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de atauqe fisico a la DF de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AF A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaFisica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaFisica = p2.GetNPC_Guitarra2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AF A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaFisica = p2.GetNPC_Bajo.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AF A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaFisica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaFisica = p2.GetNPC_Bateria.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AF A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaFisica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;
                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaFisica = p2.GetNPC_Voz.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                {
                                                    float aux = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    aux = aux * -1;

                                                    p2.DefensaFisica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueFisico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque fisico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaFisica = p2.DefensaFisica - p1.GetNPC_Voz.AtaqueFisico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueFisico + " de ataque fisico a la DF de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }
                                    break;

                                case 2:
                                    // ATAQUE MAGICO

                                    switch (rnd.Next(1, 6))
                                    {
                                        #region CASE 1 - PLAYER1 AM A PLAYER2 GUITARRA1
                                        case 1:
                                            if (p2.ExisteNPC_Guitarra1)
                                            {
                                                if ((p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra1.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra1.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Guitarra1.Nombre;
                                                        p2.GetNPC_Guitarra1 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra1.Vida = p2.GetNPC_Guitarra1.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra1.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra1.DefensaMagica = p2.GetNPC_Guitarra1.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra1.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 2 - PLAYER1 AM A PLAYER2 GUITARRA2
                                        case 2:
                                            if (p2.ExisteNPC_Guitarra2)
                                            {
                                                if ((p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Guitarra2.DefensaMagica = 0;

                                                    if (p2.GetNPC_Guitarra2.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Guitarra2.Nombre;
                                                        p2.GetNPC_Guitarra2 = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Guitarra2.Vida = p2.GetNPC_Guitarra2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Guitarra2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Guitarra2.DefensaMagica = p2.GetNPC_Guitarra2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Guitarra2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 3 - PLAYER1 AM A PLAYER2 BAJO
                                        case 3:
                                            if (p2.ExisteNPC_Bajo)
                                            {
                                                if ((p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bajo.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bajo.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Bajo.Nombre;
                                                        p2.GetNPC_Bajo = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bajo.Vida = p2.GetNPC_Bajo.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bajo.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bajo.DefensaMagica = p2.GetNPC_Bajo.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bajo.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 4 - PLAYER1 AM A PLAYER2 BATERIA
                                        case 4:
                                            if (p2.ExisteNPC_Bateria)
                                            {
                                                if ((p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Bateria.DefensaMagica = 0;

                                                    if (p2.GetNPC_Bateria.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Bateria.Nombre;
                                                        p2.GetNPC_Bateria = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Bateria.Vida = p2.GetNPC_Bateria.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Bateria.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Bateria.DefensaMagica = p2.GetNPC_Bateria.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Bateria.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                        #endregion

                                        #region CASE 5 - PLAYER1 AM A PLAYER2 VOZ
                                        case 5:
                                            if (p2.ExisteNPC_Voz)
                                            {
                                                if ((p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.GetNPC_Voz.DefensaMagica = 0;

                                                    if (p2.GetNPC_Voz.Vida - aux < 0)
                                                    {
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y destruyo a " + p2.GetNPC_Voz.Nombre;
                                                        p2.GetNPC_Voz = null;

                                                    }
                                                    else
                                                    {
                                                        p2.GetNPC_Voz.Vida = p2.GetNPC_Voz.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.GetNPC_Voz.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.GetNPC_Voz.DefensaMagica = p2.GetNPC_Voz.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico a la DM de " + p2.GetNPC_Voz.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            else
                                            {
                                                if ((p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                {
                                                    float aux = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    aux = aux * -1;

                                                    p2.DefensaMagica = 0;

                                                    if ((p2.Vida - p1.GetNPC_Voz.AtaqueMagico) < 0)
                                                    {
                                                        p2.Vida = 0;
                                                        infoCombate = p1.Nombre + " mato a " + p2.Nombre;
                                                    }
                                                    else
                                                    {
                                                        p2.Vida = p2.Vida - aux;
                                                        infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + aux + " de ataque magico a los PS de " + p2.Nombre;
                                                    }
                                                }
                                                else
                                                {
                                                    p2.DefensaMagica = p2.DefensaMagica - p1.GetNPC_Voz.AtaqueMagico;
                                                    infoCombate = p1.Nombre + " ataco con " + p1.GetNPC_Voz.Nombre + " y causo " + p1.GetNPC_Voz.AtaqueMagico + " de ataque magico la DM de " + p2.Nombre;
                                                }

                                                finDeTurno = true;
                                                rtn = true;
                                            }
                                            break;
                                            #endregion
                                    }

                                    break;
                            }
                            rtn = true;
                            #endregion
                        }
                        else
                        {
                            flagVoz = false;
                        }
                        break;
                }

                if (flagGuitarra1 == false && flagGuitarra2 == false && flagBajo == false && flagBateria == false && flagVoz == false)
                {
                    infoCombate = "NO HAY CON QUE ATACAR";
                    finDeTurno = true;
                    rtn = false;
                }

            } while (finDeTurno == false);

            return rtn;
        }
    }
}

//LA CONCHA DE TU MADRE

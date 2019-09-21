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

            bool ataqueFisico = false;
            bool ataqueMagico = false;

            bool flagGuitarra1 = true;
            bool flagGuitarra2 = true;
            bool flagBajo = true;
            bool flagBateria = true;
            bool flagVoz = true;

            Random rnd = new Random();

            if (true)      //PLAYER 1 ATACA A PLAYER 2
            {
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
                                        ataqueFisico = true;

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
                                        ataqueMagico = true;

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
                                //ataca a player 2 a cualquier npc que tenga
                                rtn = true;
                            }
                            else
                            {
                                flagGuitarra2 = false;
                            }
                            break;
                        case 3:
                            if (p1.ExisteNPC_Bajo)
                            {
                                //ataca a player 2 a cualquier npc que tenga
                                rtn = true;
                            }
                            else
                            {
                                flagBajo = false;
                            }
                            break;
                        case 4:
                            if (p1.ExisteNPC_Bateria)
                            {
                                rtn = true;
                            }
                            else
                            {
                                flagBateria = false;
                            }
                            break;
                        case 5:
                            if (p1.ExisteNPC_Voz)
                            {
                                //ataca a player 2 a cualquier npc que tenga
                                rtn = true;
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
            }

            return rtn;
        }
    }
}

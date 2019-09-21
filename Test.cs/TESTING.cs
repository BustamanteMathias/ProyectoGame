using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace Test.cs
{
    class TESTING
    {
        static void Main(string[] args)
        {
            DBCartas    DB_CARTAS   = new DBCartas();
            DBNpc       DB_NPC      = new DBNpc();

            Player p1 = new Player();
            Player p2 = new Player();

            Console.WriteLine(p1);
            NPC_Guitarra miNPC = DB_NPC.GetNPC_Guitarristas[0];

            miNPC += DB_CARTAS.GetStandard[0];  //AGREGA UNA GUITARRA A UN NPC GUITARRISTA
            miNPC += DB_CARTAS.GetStandard[0];  //AGREGA UNA GUITARRA A UN NPC GUITARRISTA
            miNPC += DB_CARTAS.GetStandard[0];  //AGREGA UNA GUITARRA A UN NPC GUITARRISTA
            miNPC += DB_CARTAS.GetStandard[0];  //VALIDA QUE SE LLENE EL NPC DE CARTAS
            miNPC += DB_CARTAS.GetStandard[11]; //VALIDA AGREGAR UN BAJO A UN NPC GUITARRISTA
            miNPC -= 2;                         //ELIMINA CARTA EN SLOT DEL NPC
            miNPC += DB_CARTAS.GetStandard[0];  //AGREGA UNA GUITARRA A UN NPC GUITARRISTA

            CartaSoporte cs = DB_CARTAS.GetMazoSoporte[1];
            p1 += cs;       //AGREGA CARTA SOPORTE
            p1 += cs;       //AGREGA CARTA SOPORTE
            p1 += cs;       //AGREGA CARTA SOPORTE
            p1 += cs;       //AGREGA CARTA SOPORTE
            p1 += cs;       //AGREGA CARTA SOPORTE
            p1 += cs;       //VALIDA QUE NO SE PUEDA AGREGAR MAS
            p1 -= 2;        //ELIMINA CARTA SOPORTE DEL SLOT
            p1 += cs;       //AGREGA CARTA SPORTE

            Console.ReadKey();

            p1 += miNPC;

            Console.WriteLine(p1);

            Console.ReadKey();
        }
    }
}

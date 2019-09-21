using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoGame;

namespace ProyectoGame
{
    public class DBCartas
    {
        private List<Carta>             DB_CARTAS               = new List<Carta>();

        private List<CartaStandard>     DB_CartasStandard       = new List<CartaStandard>();     //STANDARD
        private List<CartaRaro>         DB_CartasRaras          = new List<CartaRaro>();         //RARAS
        private List<CartaLegendario>   DB_CartasLegendarias    = new List<CartaLegendario>();   //LEGENDARIAS
        private List<CartaMitico>       DB_CartasMiticas        = new List<CartaMitico>();       //MITICAS
        private List<CartaUnico>        DB_CartasUnicas         = new List<CartaUnico>();        //UNICAS

        private List<CartaSoporte>      DB_CARTAS_SOPORTE       = new List<CartaSoporte>();      //SOPORTES

        private List<Carta> cartasGuitarra = new List<Carta>();
        private List<Carta> cartasBateria = new List<Carta>();
        private List<Carta> cartasBajo = new List<Carta>();
        private List<Carta> cartasVoz = new List<Carta>();
        private List<Carta> cartasSoporte = new List<Carta>();
        public DBCartas()
        {
            this.InstanciarStandard     (DB_CartasStandard);
            this.InstanciarRaras        (DB_CartasRaras);
            this.InstanciarLegendarias  (DB_CartasLegendarias);
            this.InstanciarMiticas      (DB_CartasMiticas);
            this.InstanciarUnicas       (DB_CartasUnicas);
            this.InstanciarSoportes     (DB_CARTAS_SOPORTE);

            #region AGREGA LAS LISTAS DE CLASES PARA RETORNAR TODAS LAS CLASES EXISTENTES SIN IMPORTAR EL GRADO
            foreach (Carta item in DB_CartasStandard)
            {
                switch (item.Clase)
                {
                    case EClase.Guitarra:
                        this.cartasGuitarra.Add(item);
                        break;
                    case EClase.Bajo:
                        this.cartasBajo.Add(item);
                        break;
                    case EClase.Bateria:
                        this.cartasBateria.Add(item);
                        break;
                    case EClase.Voz:
                        this.cartasVoz.Add(item);
                        break;
                    case EClase.Soporte:
                        this.cartasSoporte.Add(item);
                        break;
                }
            } 
            #endregion

            #region AGREGA TODAS LAS CARTAS EXISTENTES EN "DB_CARTAS"

            foreach (CartaStandard item in DB_CartasStandard)
            {
                this.DB_CARTAS.Add(item);
            }
            foreach (CartaRaro item in DB_CartasRaras)
            {
                this.DB_CARTAS.Add(item);
            }
            foreach (CartaLegendario item in DB_CartasLegendarias)
            {
                this.DB_CARTAS.Add(item);
            }
            foreach (CartaMitico item in DB_CartasMiticas)
            {
                this.DB_CARTAS.Add(item);
            }
            foreach (CartaUnico item in DB_CartasUnicas)
            {
                this.DB_CARTAS.Add(item);
            }
            #endregion
        }

        #region PROPIEDADES DE LECTURA PARA TODAS LAS LISTAS
        public List<Carta> GetMazoCompleto
        {
            get { return this.DB_CARTAS; }
        }

        #region MAZOS POR CLASE
        public List<Carta> GetMazoGuitarra
        {
            get { return this.cartasGuitarra; }
        }
        public List<Carta> GetMazoBajo
        {
            get { return this.cartasBajo; }
        }
        public List<Carta> GetMazoBateria
        {
            get { return this.cartasBateria; }
        }
        public List<Carta> GetMazoVoz
        {
            get { return this.cartasVoz; }
        }
        public List<CartaSoporte> GetMazoSoporte
        {
            get { return this.DB_CARTAS_SOPORTE; }
        }
        #endregion

        #region MAZOS POR GRADO
        public List<CartaStandard> GetStandard
        {
            get { return this.DB_CartasStandard; }
        }
        public List<CartaRaro> GetRaras
        {
            get { return this.DB_CartasRaras; }
        }
        public List<CartaLegendario> GetLegendarias
        {
            get { return this.DB_CartasLegendarias; }
        }
        public List<CartaMitico> GetMiticas
        {
            get { return this.DB_CartasMiticas; }
        }
        public List<CartaUnico> GetUnicas
        {
            get { return this.DB_CartasUnicas; }
        }  
        #endregion
        #endregion


        #region BASE DE DATOS DE TODAS LAS CARTAS
        private void InstanciarStandard(List<CartaStandard> mazoStandard)
        {
            string DESCIPCION_1000 = "NONE";

            #region CARTAS STANDARD
            //ID'S STANDARD 1000 - 1999
            //                                      ID          NIVEL       NOMBRE      DESCRIPCION         CLASE               ELEMENTO                AF      AM      DF      DM
            // GUITARRAS
            mazoStandard.Add(new CartaStandard(     1000,       1,          "CartaGuitarra0",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1001,       1,          "CartaGuitarra1",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1002,       1,          "CartaGuitarra2",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1003,       1,          "CartaGuitarra3",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1004,       1,          "CartaGuitarra4",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1005,       1,          "CartaGuitarra5",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1006,       1,          "CartaGuitarra6",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1007,       1,          "CartaGuitarra7",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1008,       1,          "CartaGuitarra8",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1009,       1,          "CartaGuitarra9",   DESCIPCION_1000,    EClase.Guitarra,    EElemento.Divino,       100,      10,      1000,      100));

            // BAJO
            mazoStandard.Add(new CartaStandard(     1000,       1,          "CartaBajo0",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1001,       1,          "CartaBajo1",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1002,       1,          "CartaBajo2",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1003,       1,          "CartaBajo3",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1004,       1,          "CartaBajo4",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1005,       1,          "CartaBajo5",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1006,       1,          "CartaBajo6",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1007,       1,          "CartaBajo7",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1008,       1,          "CartaBajo8",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1009,       1,          "CartaBajo9",   DESCIPCION_1000,    EClase.Bajo,        EElemento.Divino,       100,      10,      1000,      100));

            // BATERIA
            mazoStandard.Add(new CartaStandard(     1010,       1,          "CartaBateria0",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1011,       1,          "CartaBateria1",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1012,       1,          "CartaBateria2",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1013,       1,          "CartaBateria3",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1014,       1,          "CartaBateria4",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1015,       1,          "CartaBateria5",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1016,       1,          "CartaBateria6",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1017,       1,          "CartaBateria7",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1018,       1,          "CartaBateria8",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1019,       1,          "CartaBateria9",   DESCIPCION_1000,    EClase.Bateria,     EElemento.Divino,       100,      10,      1000,      100));

            // VOZ
            mazoStandard.Add(new CartaStandard(     1020,       1,          "CartaVoz0",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1021,       1,          "CartaVoz1",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1022,       1,          "CartaVoz2",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1023,       1,          "CartaVoz3",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1024,       1,          "CartaVoz4",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1025,       1,          "CartaVoz5",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1026,       1,          "CartaVoz6",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1027,       1,          "CartaVoz7",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1028,       1,          "CartaVoz8",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            mazoStandard.Add(new CartaStandard(     1029,       1,          "CartaVoz9",   DESCIPCION_1000,    EClase.Voz,         EElemento.Divino,       100,      10,      1000,      100));
            #endregion
        }
        private void InstanciarRaras(List<CartaRaro> mazoRaro)
        {
            string DESCIPCION_2000 = "NONE";

            #region CARTAS RARAS
            //ID'S RARO 2000 - 2999
            //                                      ID          NIVEL       NOMBRE      DESCRIPCION         CLASE               ELEMENTO                AF      AM      DF      DM      SKILL RARO

            mazoRaro.Add(new CartaRaro(             2000,       1,          "Carta0",   DESCIPCION_2000,    EClase.Guitarra,     EElemento.Divino,       1,      1,      1,      1,      ESkillsRaro.Skill_1));
            #endregion
        }
        private void InstanciarLegendarias(List<CartaLegendario> mazoLegendario)
        {
            string DESCIPCION_3000 = "NONE";

            #region CARTAS LEGENDARIAS
            //ID'S RARO 3000 - 3999
            //                                      ID          NIVEL       NOMBRE      DESCRIPCION         CLASE               ELEMENTO                AF      AM      DF      DM      SKILL RARO              SKILL LEGENDARIO

            mazoLegendario.Add(new CartaLegendario( 3000,       1,          "Carta0",   DESCIPCION_3000,    EClase.Guitarra,    EElemento.Divino,       1,      1,      1,      1,      ESkillsRaro.Skill_1,    ESkillsLegendario.Skill_1));
            #endregion
        }
        private void InstanciarMiticas(List<CartaMitico> mazoMitico)
        {
            string DESCIPCION_4000 = "NONE";

            #region CARTAS MITICAS
            //ID'S RARO 4000 - 4999
            //                                      ID          NIVEL       NOMBRE      DESCRIPCION         CLASE               ELEMENTO                AF      AM      DF      DM      SKILL RARO              SKILL LEGENDARIO            SKILL MITICO

            mazoMitico.Add(new CartaMitico(         4000,       1,          "Carta0",   DESCIPCION_4000,    EClase.Guitarra,    EElemento.Divino,       1,      1,      1,      1,      ESkillsRaro.Skill_1,    ESkillsLegendario.Skill_1,  ESkillsMitico.Skill_1));
            #endregion
        }
        private void InstanciarUnicas(List<CartaUnico> mazoUnico)
        {
            string DESCIPCION_5000 = "NONE";

            #region CARTAS UNICAS
            //ID'S RARO 5000 - 5999
            //                                      ID          NIVEL       NOMBRE      DESCRIPCION         CLASE               ELEMENTO                AF      AM      DF      DM      SKILL RARO              SKILL LEGENDARIO            SKILL MITICO            SKILL MITICO

            mazoUnico.Add(new CartaUnico(           5000,       1,          "Carta0",   DESCIPCION_5000,    EClase.Guitarra,    EElemento.Divino,       1,      1,      1,      1,      ESkillsRaro.Skill_1,    ESkillsLegendario.Skill_1,  ESkillsMitico.Skill_1,  ESkillsUnico.Skill_1));
            #endregion
        }
        private void InstanciarSoportes(List<CartaSoporte> mazoSoporte)
        {
            string DESCIPCION_6000 = "NONE";

            #region CARTAS SOPORTES
            //ID'S RARO 6000 -
            //                                      ID          NOMBRE          DESCRIPCION         VIDA        DF          DM

            mazoSoporte.Add(new CartaSoporte(       6999,       "NONE",         DESCIPCION_6000,    0,          0,          0));
            mazoSoporte.Add(new CartaSoporte(       6000,       "Soporte1",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6001,       "Soporte2",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6002,       "Soporte3",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6003,       "Soporte4",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6004,       "Soporte5",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6005,       "Soporte6",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6006,       "Soporte7",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6007,       "Soporte8",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6008,       "Soporte9",     DESCIPCION_6000,    10000,      1000,       1000));
            mazoSoporte.Add(new CartaSoporte(       6009,       "Soporte10",     DESCIPCION_6000,    10000,      1000,       1000));
            #endregion
        }
        #endregion


        public void Mostrar()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tBASE DE DATOS CARTAS\n\n");

            foreach (Carta item in this.DB_CARTAS)
            {
                switch (item.Grado)
                {
                    case EGrado.Standar:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(item);
                        break;
                    case EGrado.Raro:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(item);
                        break;
                    case EGrado.Legendario:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(item);
                        break;
                    case EGrado.Mitico:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(item);
                        break;
                    case EGrado.Unico:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(item);
                        break;
                }
            }
            foreach (CartaSoporte item in this.DB_CARTAS_SOPORTE)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(item);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        public Carta this[int index]
        {
            get
            {
                if (index > -1 && index < this.DB_CARTAS.Count)
                {
                    return this.DB_CARTAS[index];
                }
                else
                {
                    return null;
                }
            }

        }
    }
}

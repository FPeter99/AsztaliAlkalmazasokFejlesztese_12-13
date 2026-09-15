using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    using InterfaceLibrary1;
    using System;

    public class Foglalas : IFoglalas
    {

        public string HelyszinAzonosito { get; init; }
        public DateTime Kezdete { get; init; }
        public int IdotartamPercben { get; init; }
        public DateTime Vege => Kezdete.AddMinutes(IdotartamPercben);


        public string TanarAzonosito { get; private set; }


        public Foglalas(string helyszinAzonosito, DateTime kezdete, int idotartamPercben, string tanarAzonosito)
        {

            if (idotartamPercben <= 0 || idotartamPercben % 15 != 0)
            {
                throw new IdotartamException();
            }

            Kezdete = kezdete;
            HelyszinAzonosito = helyszinAzonosito;
            TanarAzonosito = tanarAzonosito;
            IdotartamPercben = idotartamPercben;
        }

        


        public override string ToString()
        {
            return $"Foglalás: Kezdete: {Kezdete}, Vége: {Vege}, Tanár ID: {TanarAzonosito}";
        }
    }
}

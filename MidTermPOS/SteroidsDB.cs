using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermPOS
{
    class SteroidsDB
    {
        public List<DrugType> DrugName = new List<DrugType>();
        public SteroidsDB()
        {
            DrugName.Add(new DrugType("Better Hair", 4.99 , "Hair growth treatment clinically proven to grow hair in 1 week guaranteed!"));
            DrugName.Add(new DrugType("Supa Strength", 9.99, "Need to look buff for your lady? Look no further, Supa Strength will give you the muscles you need to impress."));
            DrugName.Add(new DrugType("Test-O", 3.99,"Lacking energy? The drive to get things done? Test-O will boost your levels to 11"));
            DrugName.Add(new DrugType("Prednisone", 3.50, "Prednisone is used to treat conditions such as arthritis, blood disorders, breathing problems, severe allergies, skin diseases, cancer, eye problems, and immune system disorders. "));
        }
    }
}

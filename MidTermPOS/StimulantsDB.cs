using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermPOS
{
    class StimulantsDB  
    {
        public List<DrugType> DrugName = new List<DrugType>();
        public StimulantsDB()
        {
            DrugName.Add(new DrugType("Adderall", 5.44, "Amphetamine/dextroamphetamine belongs to a class of drugs known as stimulants. It can help increase your ability to pay attention, stay focused on an activity, and control behavior problems."));
            DrugName.Add(new DrugType("Ritalin", 3.45, " Methylphenidate belongs to a class of drugs known as stimulants. It can help increase your ability to pay attention, stay focused on an activity, and control behavior problems. "));
            DrugName.Add(new DrugType("Concerta", 2.56, "This medication is used to treat attention deficit hyperactivity disorder - ADHD. It works by changing the amounts of certain natural substances in the brain."));
            DrugName.Add(new DrugType("Focalin",1.45, " Dexmethylphenidate belongs to a class of drugs known as stimulants. It can help increase your ability to pay attention, stay focused on an activity, and control behavior problems."));
        }
    }
}

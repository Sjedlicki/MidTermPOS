using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermPOS
{
     class DepressantDB
    {
        public List<DrugType> DrugName = new List<DrugType>();
        public DepressantDB()
        {
            DrugName.Add(new DrugType("SleepEZ", 2.34, "Used to treat a certain sleep problem (insomnia) in adults. If you have trouble falling asleep, it helps you fall asleep faster, so you can get a better night's rest."));
            DrugName.Add(new DrugType("Xanax", 4.54, "Alprazolam is used to treat anxiety and panic disorders. It belongs to a class of medications called benzodiazepines which act on the brain and nerves (central nervous system) to produce a calming effect."));
            DrugName.Add(new DrugType("Klonopin", 9.23, "Clonazepam is used to prevent and control seizures. This medication is known as an anticonvulsant or antiepileptic drug. It is also used to treat panic attacks. Clonazepam works by calming your brain and nerves."));
            DrugName.Add(new DrugType("Valium", 8.76, "Diazepam is used to treat anxiety, alcohol withdrawal, and seizures. It is also used to relieve muscle spasms and to provide sedation before medical procedures. This medication works by calming the brain and nerves."));
        }
    }
}

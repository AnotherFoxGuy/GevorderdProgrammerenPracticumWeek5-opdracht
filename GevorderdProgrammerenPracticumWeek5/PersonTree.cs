using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GevorderdProgrammerenPracticumWeek5
{
    public class PersonTree
    {
        #region given code
        private Person person;
        private PersonTree lessEvil;
        private PersonTree moreEvil;

        public PersonTree(Person p)
        {
            person = p;
        }

        public string GetPersonName()
        {
            return person.GetName();
        }

        public string GetMostEvilPerson()
        {
            return moreEvil == null ? person.GetName() : moreEvil.GetMostEvilPerson();
        }
        #endregion

        public void Add(Person p)
        {
            if (p != person)
            {
                if (p.IsMoreEvil(person))
                    if (moreEvil == null)
                        moreEvil = new PersonTree(p);
                    else
                        moreEvil.Add(p);
                else if (lessEvil == null)
                    lessEvil = new PersonTree(p);
                else
                    lessEvil.Add(p);
            }
        }

        /// <summary>
        /// return names of persons in the tree sorted from good to evil
        /// </summary>
        /// <returns>names of persons in the tree sorted from good to evil</returns>
        public string GetAllNamesSorted()
        {
            return (lessEvil != null ? lessEvil.GetAllNamesSorted() + " - " : "") + $"{person.GetName()}" + (moreEvil != null ? " - " + moreEvil.GetAllNamesSorted() : "");
        }
    }
}

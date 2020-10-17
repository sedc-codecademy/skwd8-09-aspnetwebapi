using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Shared.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message)
        {
            
        }
        public NotFoundException(int id) : base($"Resource with id {id} was not found!")
        {

        }

    }
}

using LabBook.ADO;
using LabBook.Commons;
using LabBook.Forms.LabBook;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LabBook.Service
{
    public class LabBookService
    {
        private static readonly string dataFormFileName = "LabBookForm";

        private readonly User _user;
        private readonly SqlConnection _connection;
        private readonly LabBookForm labBookForm;

        public LabBookService(LabBookForm labBookForm, SqlConnection connection, User user)
        {
            _user = user;
            _connection = connection;
            this.labBookForm = labBookForm;
        }

        #region Save and Load data form LabBook form

        public void SaveFormData(LabBookForm labBookForm)
        {
            List<double> list = new List<double>
            {
                labBookForm.Left,
                labBookForm.Top,
                labBookForm.Width,
                labBookForm.Height,
            };
            CommonFunction.WriteWindowsData(list, dataFormFileName);
        }

        internal void LoadFormData(LabBookForm labBookForm)
        {
            List<double> list = CommonFunction.LoadWindowsData(dataFormFileName);

            if (list.Count == 4)
            {
                labBookForm.Left = (int)list[0];
                labBookForm.Top = (int)list[1];
                labBookForm.Width = (int)list[2];
                labBookForm.Height = (int)list[3];
            }
        }

        #endregion
    }
}

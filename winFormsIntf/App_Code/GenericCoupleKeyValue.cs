using System;
using System.Text;


namespace winFormsIntf.App_Code
{


    public class GenericCoupleKeyValue
    {
        private string fieldName;
        private int fieldId;
        //
        public GenericCoupleKeyValue(string fieldName_par, int fieldId_par)
        {
            this.fieldId = fieldId_par;
            this.fieldName = fieldName_par;
        }

        public override string ToString()
        {
            return this.fieldName;
        }

        public int getId()
        {
            return this.fieldId;
        }
    };


}// nmsp

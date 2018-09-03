using System;
using CharacterEditor.Model;

namespace CharacterEditor.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Character editor");
            callback(item, null);
        }
    }
}
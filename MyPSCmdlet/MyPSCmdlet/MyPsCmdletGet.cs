using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace MyPSCmdlet
{
    [Cmdlet(VerbsCommon.Get, "MyPSCmdlet")]
    public class MyPsCmdletGet : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter CreatedTomorrow;

        [Parameter(Mandatory = false)]
        public MyObject MyObj;

        [Parameter(Mandatory = false)]
        public string ObjectName;
        protected override void ProcessRecord()
        {
            var myobj = new MyObject()
            {
                Name = "My Object",
                Created = DateTime.Now
            };

            if (CreatedTomorrow.IsPresent)
                myobj.Created = DateTime.Now.AddDays(1);

            if (!string.IsNullOrEmpty(ObjectName))
                myobj.Name = ObjectName;

            if (MyObj != null)
                myobj = MyObj;

            WriteObject(myobj);
        }
    }
    

    public class MyObject
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
    }
}

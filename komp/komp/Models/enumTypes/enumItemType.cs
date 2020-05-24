using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace komp.Models.enumTypes
{
    public enum enumItemType
    {
        [Description("korpusas")]
       korpusas,
       [Description("pagrindinėPlokštė")]
        pagrindinėPlokštė,
        [Description("procesorius")]
        procesorius,
        [Description("vaizdoPlokštė")]
        vaizdoPlokštė,
        [Description("ram")]
        ram,
        [Description("atmintiesįrenginys")]
        atmintiesĮrenginys,
        [Description("aušintuvas")]
        aušintuvas,
        [Description("maitinimoBlokas")]
        maitinimoBlokas,
        [Description("monitorius")]
        monitorius,
        [Description("pelė")]
        pelė,
        [Description("klaviatūra")]
        klaviatūra


    }
}
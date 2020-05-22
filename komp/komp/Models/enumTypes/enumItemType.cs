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
       [Description("pagrindinė plokštė")]
        pagrindinėPlokštė,
        [Description("procesorius")]
        procesorius,
        [Description("vaizdo plokštė")]
        vaizdoPlokštė,
        [Description("ram")]
        ram,
        [Description("atminties įrenginys")]
        atmintiesĮrenginys,
        [Description("aušintuvas")]
        aušintuvas,
        [Description("maitinimo blokas")]
        maitinimoBlokas,
        [Description("monitorius")]
        monitorius,
        [Description("pelė")]
        pelė,
        [Description("klaviatūra")]
        klaviatūra


    }
}
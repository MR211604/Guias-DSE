using LibrosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibrosDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LibrosDbContext>>()))
            {
                context.Libros.AddRange(
                    new Libro
                    {
                        Titulo = "Heloderma horridum",
                        Autor = "Mina",
                        AnioPublicacion = 1991
                    }, new Libro
                    {
                        Titulo = "Macropus robustus",
                        Autor = "Upton",
                        AnioPublicacion = 2026
                    }, new Libro
                    {
                        Titulo = "Anathana ellioti",
                        Autor = "Quinton",
                        AnioPublicacion = 2000
                    }, new Libro
                    {
                        Titulo = "Bubo virginianus",
                        Autor = "Wakefield",
                        AnioPublicacion = 2010
                    }, new Libro
                    {
                        Titulo = "Raphicerus campestris",
                        Autor = "Dunc",
                        AnioPublicacion = 2017
                    }, new Libro
                    {
                        Titulo = "Alopex lagopus",
                        Autor = "Walden",
                        AnioPublicacion = 2015
                    }, new Libro
                    {
                        Titulo = "Eolophus roseicapillus",
                        Autor = "Robina",
                        AnioPublicacion = 1997
                    }, new Libro
                    {
                        Titulo = "Tenrec ecaudatus",
                        Autor = "Arturo",
                        AnioPublicacion = 2020
                    }, new Libro
                    {
                        Titulo = "Limosa haemastica",
                        Autor = "Mandy",
                        AnioPublicacion = 2020
                    }, new Libro
                    {
                        Titulo = "Sarcophilus harrisii",
                        Autor = "Ofilia",
                        AnioPublicacion = 1996
                    }, new Libro
                    {
                        Titulo = "Varanus sp.",
                        Autor = "Ulberto",
                        AnioPublicacion = 2013
                    }, new Libro
                    {
                        Titulo = "Semnopithecus entellus",
                        Autor = "Ara",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Pedetes capensis",
                        Autor = "Francoise",
                        AnioPublicacion = 2019
                    }, new Libro
                    {
                        Titulo = "Macaca nemestrina",
                        Autor = "Silvio",
                        AnioPublicacion = 2009
                    }, new Libro
                    {
                        Titulo = "Pelecans onocratalus",
                        Autor = "Dierdre",
                        AnioPublicacion = 2011
                    }, new Libro
                    {
                        Titulo = "Pteronura brasiliensis",
                        Autor = "Carlie",
                        AnioPublicacion = 2016
                    }, new Libro
                    {
                        Titulo = "Alcelaphus buselaphus caama",
                        Autor = "Derby",
                        AnioPublicacion = 1991
                    }, new Libro
                    {
                        Titulo = "Gazella granti",
                        Autor = "Maxim",
                        AnioPublicacion = 2012
                    }, new Libro
                    {
                        Titulo = "Plectopterus gambensis",
                        Autor = "Fonz",
                        AnioPublicacion = 2003
                    }, new Libro
                    {
                        Titulo = "Cercatetus concinnus",
                        Autor = "Beret",
                        AnioPublicacion = 1998
                    }, new Libro
                    {
                        Titulo = "Macropus eugenii",
                        Autor = "Somerset",
                        AnioPublicacion = 2008
                    }, new Libro
                    {
                        Titulo = "Actophilornis africanus",
                        Autor = "Allie",
                        AnioPublicacion = 2002
                    }, new Libro
                    {
                        Titulo = "Alcelaphus buselaphus caama",
                        Autor = "Alayne",
                        AnioPublicacion = 2026
                    }, new Libro
                    {
                        Titulo = "unavailable",
                        Autor = "Giselbert",
                        AnioPublicacion = 2013
                    }, new Libro
                    {
                        Titulo = "Francolinus swainsonii",
                        Autor = "Jermain",
                        AnioPublicacion = 2021
                    }, new Libro
                    {
                        Titulo = "Myrmecobius fasciatus",
                        Autor = "Anthea",
                        AnioPublicacion = 2002
                    }, new Libro
                    {
                        Titulo = "Anas punctata",
                        Autor = "Mathew",
                        AnioPublicacion = 2012
                    }, new Libro
                    {
                        Titulo = "Aonyx capensis",
                        Autor = "Alisander",
                        AnioPublicacion = 2023
                    }, new Libro
                    {
                        Titulo = "Plegadis ridgwayi",
                        Autor = "Almire",
                        AnioPublicacion = 2000
                    }, new Libro
                    {
                        Titulo = "Cebus albifrons",
                        Autor = "Chandra",
                        AnioPublicacion = 1994
                    }, new Libro
                    {
                        Titulo = "Spermophilus lateralis",
                        Autor = "Jeana",
                        AnioPublicacion = 2012
                    }, new Libro
                    {
                        Titulo = "Podargus strigoides",
                        Autor = "Kienan",
                        AnioPublicacion = 2019
                    }, new Libro
                    {
                        Titulo = "Dasypus novemcinctus",
                        Autor = "Clair",
                        AnioPublicacion = 2026
                    }, new Libro
                    {
                        Titulo = "Phalaropus fulicarius",
                        Autor = "Clarance",
                        AnioPublicacion = 2010
                    }, new Libro
                    {
                        Titulo = "Ceratotherium simum",
                        Autor = "Chrotoem",
                        AnioPublicacion = 2013
                    }, new Libro
                    {
                        Titulo = "Myotis lucifugus",
                        Autor = "Mirna",
                        AnioPublicacion = 2009
                    }, new Libro
                    {
                        Titulo = "Lasiodora parahybana",
                        Autor = "Westleigh",
                        AnioPublicacion = 2006
                    }, new Libro
                    {
                        Titulo = "Lama glama",
                        Autor = "Simon",
                        AnioPublicacion = 2017
                    }, new Libro
                    {
                        Titulo = "Eubalaena australis",
                        Autor = "Tracey",
                        AnioPublicacion = 2000
                    }, new Libro
                    {
                        Titulo = "Ceratotherium simum",
                        Autor = "Myrvyn",
                        AnioPublicacion = 2018
                    }, new Libro
                    {
                        Titulo = "Callipepla gambelii",
                        Autor = "Josey",
                        AnioPublicacion = 2011
                    }, new Libro
                    {
                        Titulo = "Cynomys ludovicianus",
                        Autor = "Mil",
                        AnioPublicacion = 2017
                    }, new Libro
                    {
                        Titulo = "Acrobates pygmaeus",
                        Autor = "Jeff",
                        AnioPublicacion = 2023
                    }, new Libro
                    {
                        Titulo = "Chionis alba",
                        Autor = "Alysa",
                        AnioPublicacion = 2000
                    }, new Libro
                    {
                        Titulo = "Thalasseus maximus",
                        Autor = "Candi",
                        AnioPublicacion = 1995
                    }, new Libro
                    {
                        Titulo = "Antilope cervicapra",
                        Autor = "Thornton",
                        AnioPublicacion = 1990
                    }, new Libro
                    {
                        Titulo = "Camelus dromedarius",
                        Autor = "Adan",
                        AnioPublicacion = 1995
                    }, new Libro
                    {
                        Titulo = "Haliaetus leucogaster",
                        Autor = "Oran",
                        AnioPublicacion = 2024
                    }, new Libro
                    {
                        Titulo = "Felis silvestris lybica",
                        Autor = "Dalenna",
                        AnioPublicacion = 2019
                    }, new Libro
                    {
                        Titulo = "Stercorarius longicausus",
                        Autor = "Ferdie",
                        AnioPublicacion = 2011
                    }, new Libro
                    {
                        Titulo = "Chamaelo sp.",
                        Autor = "Emelita",
                        AnioPublicacion = 2009
                    }, new Libro
                    {
                        Titulo = "Eudromia elegans",
                        Autor = "Anne-marie",
                        AnioPublicacion = 2021
                    }, new Libro
                    {
                        Titulo = "Dromaeus novaehollandiae",
                        Autor = "Timmie",
                        AnioPublicacion = 1993
                    }, new Libro
                    {
                        Titulo = "Choloepus hoffmani",
                        Autor = "Jourdan",
                        AnioPublicacion = 1990
                    }, new Libro
                    {
                        Titulo = "Mazama americana",
                        Autor = "Trista",
                        AnioPublicacion = 1992
                    }, new Libro
                    {
                        Titulo = "unavailable",
                        Autor = "Lezley",
                        AnioPublicacion = 2026
                    }, new Libro
                    {
                        Titulo = "Stenella coeruleoalba",
                        Autor = "Eleanor",
                        AnioPublicacion = 2005
                    }, new Libro
                    {
                        Titulo = "Larus dominicanus",
                        Autor = "Jayne",
                        AnioPublicacion = 2023
                    }, new Libro
                    {
                        Titulo = "Paradoxurus hermaphroditus",
                        Autor = "Karmen",
                        AnioPublicacion = 2017
                    }, new Libro
                    {
                        Titulo = "Cygnus atratus",
                        Autor = "Octavia",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Vanellus sp.",
                        Autor = "Julianna",
                        AnioPublicacion = 2001
                    }, new Libro
                    {
                        Titulo = "Acrantophis madagascariensis",
                        Autor = "Arvie",
                        AnioPublicacion = 2012
                    }, new Libro
                    {
                        Titulo = "Branta canadensis",
                        Autor = "Holly",
                        AnioPublicacion = 1997
                    }, new Libro
                    {
                        Titulo = "Butorides striatus",
                        Autor = "Jack",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Ciconia ciconia",
                        Autor = "Elijah",
                        AnioPublicacion = 1993
                    }, new Libro
                    {
                        Titulo = "Galictis vittata",
                        Autor = "Harlene",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Ovis canadensis",
                        Autor = "Shannah",
                        AnioPublicacion = 2001
                    }, new Libro
                    {
                        Titulo = "Zenaida galapagoensis",
                        Autor = "Allsun",
                        AnioPublicacion = 1990
                    }, new Libro
                    {
                        Titulo = "Dusicyon thous",
                        Autor = "Simeon",
                        AnioPublicacion = 2019
                    }, new Libro
                    {
                        Titulo = "Haliaetus leucogaster",
                        Autor = "Cory",
                        AnioPublicacion = 2004
                    }, new Libro
                    {
                        Titulo = "Limnocorax flavirostra",
                        Autor = "Bale",
                        AnioPublicacion = 2016
                    }, new Libro
                    {
                        Titulo = "Tachybaptus ruficollis",
                        Autor = "Dennie",
                        AnioPublicacion = 2012
                    }, new Libro
                    {
                        Titulo = "Mycteria ibis",
                        Autor = "Kamila",
                        AnioPublicacion = 2021
                    }, new Libro
                    {
                        Titulo = "Equus burchelli",
                        Autor = "Case",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Delphinus delphis",
                        Autor = "Cosimo",
                        AnioPublicacion = 2018
                    }, new Libro
                    {
                        Titulo = "Spermophilus lateralis",
                        Autor = "Crysta",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Passer domesticus",
                        Autor = "Annecorinne",
                        AnioPublicacion = 2002
                    }, new Libro
                    {
                        Titulo = "Lorythaixoides concolor",
                        Autor = "Tiffie",
                        AnioPublicacion = 2018
                    }, new Libro
                    {
                        Titulo = "Cebus apella",
                        Autor = "Cory",
                        AnioPublicacion = 2005
                    }, new Libro
                    {
                        Titulo = "Paraxerus cepapi",
                        Autor = "Herminia",
                        AnioPublicacion = 2016
                    }, new Libro
                    {
                        Titulo = "Cynictis penicillata",
                        Autor = "Lind",
                        AnioPublicacion = 2016
                    }, new Libro
                    {
                        Titulo = "Galago crassicaudataus",
                        Autor = "Antony",
                        AnioPublicacion = 2018
                    }, new Libro
                    {
                        Titulo = "Odocoileus hemionus",
                        Autor = "Ransom",
                        AnioPublicacion = 2008
                    }, new Libro
                    {
                        Titulo = "Meleagris gallopavo",
                        Autor = "Doro",
                        AnioPublicacion = 1997
                    }, new Libro
                    {
                        Titulo = "Theropithecus gelada",
                        Autor = "Lilly",
                        AnioPublicacion = 2017
                    }, new Libro
                    {
                        Titulo = "Oxybelis fulgidus",
                        Autor = "Abigael",
                        AnioPublicacion = 1997
                    }, new Libro
                    {
                        Titulo = "Tachybaptus ruficollis",
                        Autor = "Clifford",
                        AnioPublicacion = 1998
                    }, new Libro
                    {
                        Titulo = "Nectarinia chalybea",
                        Autor = "Troy",
                        AnioPublicacion = 2003
                    }, new Libro
                    {
                        Titulo = "Ursus americanus",
                        Autor = "Nichole",
                        AnioPublicacion = 2016
                    }, new Libro
                    {
                        Titulo = "unavailable",
                        Autor = "Cornie",
                        AnioPublicacion = 1999
                    }, new Libro
                    {
                        Titulo = "Streptopelia senegalensis",
                        Autor = "Orbadiah",
                        AnioPublicacion = 1990
                    }, new Libro
                    {
                        Titulo = "Delphinus delphis",
                        Autor = "Lesya",
                        AnioPublicacion = 2005
                    }, new Libro
                    {
                        Titulo = "Junonia genoveua",
                        Autor = "Wilmar",
                        AnioPublicacion = 1995
                    }, new Libro
                    {
                        Titulo = "Porphyrio porphyrio",
                        Autor = "Eloise",
                        AnioPublicacion = 2001
                    }, new Libro
                    {
                        Titulo = "Phoeniconaias minor",
                        Autor = "Rasia",
                        AnioPublicacion = 1995
                    }, new Libro
                    {
                        Titulo = "Streptopelia senegalensis",
                        Autor = "Lynnell",
                        AnioPublicacion = 2020
                    }, new Libro
                    {
                        Titulo = "Odocoileus hemionus",
                        Autor = "Lilah",
                        AnioPublicacion = 1996
                    }, new Libro
                    {
                        Titulo = "Corvus brachyrhynchos",
                        Autor = "Melicent",
                        AnioPublicacion = 1995
                    }, new Libro
                    {
                        Titulo = "Myrmecobius fasciatus",
                        Autor = "Marchelle",
                        AnioPublicacion = 2014
                    }, new Libro
                    {
                        Titulo = "Drymarchon corias couperi",
                        Autor = "Mort",
                        AnioPublicacion = 2011
                    }
                );
            }
        }
    }
}

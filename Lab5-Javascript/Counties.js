const citiesByCounty = {
    "Alba": ["Alba Iulia", "Aiud", "Blaj"],
    "Arad": ["Arad", "Ineu", "Lipova"],
    "Arges": ["Pitesti", "Campulung", "Curtea de Arges"],
    "Bacau": ["Buhusi","Bacau", "Onesti", "Roman"],
    "Bihor": ["Oradea", "Salonta", "Marghita"],
    "Bistrita-Nasaud": ["Bistrita", "Nasaud", "Beclean"],
    "Botosani": ["Botosani", "Dorohoi", "Saveni"],
    "Braila": ["Braila", "Ianca", "Insuratei"],
    "Brasov": ["Brasov", "Fagaras", "Sacele"],
    "Bucuresti":["Bucuresti"],
    "Buzau": ["Buzau", "Rm. Sarat", "Nehoiu"],
    "Calarasi": ["Calarasi", "Oltenita", "Fundulea"],
    "Caras-Severin": ["Resita", "Caransebes", "Oravita"],
    "Cluj": ["Cluj-Napoca", "Turda", "Dej"],
    "Constanta": ["Constanta", "Medgidia", "Navodari"],
    "Covasna": ["Sfantu Gheorghe", "Targu Secuiesc", "Covasna"],
    "Dambovita": ["Targoviste", "Pucioasa", "Moreni"],
    "Dolj": ["Craiova", "Bailesti", "Filiasi"],
    "Galati": ["Galati", "Tecuci", "Targu Bujor"],
    "Giurgiu": ["Giurgiu", "Bolintin Vale", "Mihailesti"],
    "Gorj": ["Targu Jiu", "Motru", "Rovinari"],
    "Harghita": ["Miercurea Ciuc", "Gheorgheni", "Odorheiu Secuiesc"],
    "Hunedoara": ["Deva", "Hunedoara", "Petrosani"],
    "Ialomita": ["Slobozia", "Urziceni", "Fetesti"],
    "Iasi": ["Iasi", "Pascani", "Harlau"],
    "Ilfov": ["Voluntari", "Buftea", "Pantelimon"],
    "Maramures": ["Baia Mare", "Sighetu Marmatiei", "Baia Sprie"],
    "Mehedinti": ["Drobeta-Turnu Severin", "Orsova", "Strehaia"],
    "Mures": ["Targu Mures", "Sighisoara", "Reghin"],
    "Neamt": ["Piatra Neamt", "Roman", "Targu Neamt"],
    "Olt": ["Slatina", "Caracal", "Corabia"],
    "Prahova": ["Ploiesti", "Baicoi", "Breaza"],
    "Salaj": ["Zalau", "Simleu Silvaniei", "Jibou"],
    "Satu Mare": ["Satu Mare", "Carei", "Negresti-Oas"],
    "Sibiu": ["Sibiu", "Medias", "Avrig"],
    "Suceava": ["Suceava", "Falticeni", "Radauti","Vatra Dornei"],
    "Teleorman": ["Alexandria", "Rosiorii de Vede", "Turnu Magurele"],
    "Timis": ["Timisoara", "Lugoj", "Jimbolia"],
    "Tulcea": ["Tulcea", "Macin", "Babadag"],
    "Valcea": ["Ramnicu Valcea", "Dragasani", "Horezu"],
    "Vaslui": ["Vaslui", "Barlad", "Husi"],
    "Vrancea": ["Focsani", "Adjud", "Panciu"]
};


window.onload = function() {
    const countySelect = document.getElementById("countySelect");
    const citySelect = document.getElementById("citySelect");

    countySelect.onchange = function() {
        const selectedCounty = countySelect.value;
        const cities = citiesByCounty[selectedCounty] || [];

        citySelect.length = 0; 
        citySelect.options.add(new Option("Select City", "")); 

        cities.forEach(city => {
            const option = new Option(city, city);
            citySelect.options.add(option);
        });
    };
};
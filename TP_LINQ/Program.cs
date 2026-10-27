using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Produit> produits = new List<Produit>
{
    new Produit { Id = 1, Nom = "Clavier", Categorie = "Informatique", Prix = 80 },
    new Produit { Id = 2, Nom = "Souris",  Categorie = "Informatique", Prix = 40 },
    new Produit { Id = 3, Nom = "Ecran",   Categorie = "Informatique", Prix = 650 },
    new Produit { Id = 4, Nom = "Chaise",  Categorie = "Mobilier",     Prix = 220 },
    new Produit { Id = 5, Nom = "Bureau",  Categorie = "Mobilier",     Prix = 450 },
    new Produit { Id = 6, Nom = "Casque",  Categorie = "Informatique", Prix = 95 }
};

void Afficher(IEnumerable<Produit> liste)
{
    if (!liste.Any())
    {
        Console.WriteLine("Aucun produit.");
        return;
    }
    foreach (var p in liste)
        Console.WriteLine($"{p.Nom} | {p.Categorie} | {p.Prix} DT");
}

int choix;
do
{
    Console.WriteLine("\n===== GESTION DES PRODUITS =====");
    Console.WriteLine("1. Afficher tous les produits");
    Console.WriteLine("2. Afficher les produits à moins de 100 DT");
    Console.WriteLine("3. Trier par prix");
    Console.WriteLine("4. Rechercher par catégorie");
    Console.WriteLine("5. Afficher les statistiques");
    Console.WriteLine("6. Rechercher un produit");
    Console.WriteLine("0. Quitter");
    Console.Write("Votre choix : ");

    if (!int.TryParse(Console.ReadLine(), out choix))
        choix = -1;

    Console.WriteLine();
    switch (choix)
    {
        case 1:
            Afficher(produits);
            break;
        case 2:
            Afficher(produits.Where(p => p.Prix < 100));
            break;
        case 3:
            Afficher(produits.OrderBy(p => p.Prix));
            break;
        case 4:
            Console.Write("Catégorie : ");
            string cat = Console.ReadLine() ?? "";
            Afficher(produits.Where(p =>
                p.Categorie.Equals(cat, StringComparison.OrdinalIgnoreCase)));
            break;
        case 5:
            Console.WriteLine($"Nombre de produits : {produits.Count()}");
            Console.WriteLine($"Prix moyen : {produits.Average(p => p.Prix):F2} DT");
            break;
        case 6:
            Console.Write("Nom du produit : ");
            string nom = Console.ReadLine() ?? "";
            var trouve = produits.FirstOrDefault(p =>
                p.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
            if (trouve != null)
                Console.WriteLine($"Trouvé : {trouve.Id} | {trouve.Nom} | {trouve.Categorie} | {trouve.Prix} DT");
            else
                Console.WriteLine("Produit introuvable.");
            break;
        case 0:
            Console.WriteLine("Au revoir !");
            break;
        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
} while (choix != 0);
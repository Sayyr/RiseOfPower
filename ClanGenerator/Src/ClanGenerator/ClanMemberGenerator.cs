using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;
using System;
using System.Reflection;

public static class ClanMemberGenerator
{
    public static Hero CreateGenericHeroForClan(Clan clan, int index)
    {
        // Créer une instance de Hero sans appeler de constructeur public
        Hero newHero = (Hero)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Hero));

        // Ici, on effectue une initialisation basique.
        // Par exemple, on peut attribuer un nom générique et assigner le clan.
        // Note : Dans une approche plus complète, il faudrait appeler les méthodes d'initialisation internes.
        string heroName = "Membre " + index;
        newHero.Name = new TextObject(heroName).ToString();
        newHero.Clan = clan;

        // Ajout du nouveau héros à la liste des membres du clan
        // Certains mods utilisent une méthode interne ou modifient directement la collection.
        // On utilise ici une méthode fictive 'AddMember' qui devrait être disponible (ou via manipulation de la collection).
        clan.AddMember(newHero);

        // Optionnel : afficher un message en jeu
        InformationManager.DisplayMessage(new InformationMessage("Nouveau membre ajouté : " + heroName));

        return newHero;
    }

    // Méthode pour générer plusieurs membres pour un clan
    public static void GenerateGenericMembers(Clan clan, int numberOfMembers)
    {
        for (int i = 1; i <= numberOfMembers; i++)
        {
            CreateGenericHeroForClan(clan, i);
        }
    }
}

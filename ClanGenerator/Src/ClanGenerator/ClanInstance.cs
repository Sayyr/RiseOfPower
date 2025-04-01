using System;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Localization;

public static class ClanCreator
{
    public static Clan CreateNewClan(string clanName, Hero leader, Kingdom kingdom)
    {
        if (leader == null)
            throw new ArgumentNullException(nameof(leader));
        if (kingdom == null)
            throw new ArgumentNullException(nameof(kingdom));

        // Créer une instance non initialisée de Clan.
        Clan newClan = (Clan)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Clan));

        // Rechercher la méthode non publique qui initialise le clan.
        // Le nom et la signature de cette méthode peuvent varier selon la version du jeu.
        MethodInfo initMethod = typeof(Clan).GetMethod("InitializeClan", BindingFlags.NonPublic | BindingFlags.Instance);
        if (initMethod == null)
            throw new Exception("La méthode d'initialisation du clan n'a pas été trouvée.");

        // Appeler la méthode d'initialisation. La signature exacte attendue est généralement :
        // void InitializeClan(string clanName, Hero leader, Kingdom kingdom)
        initMethod.Invoke(newClan, new object[] { clanName, leader, kingdom });

        // Ajout du clan à la campagne. Cela permet à la campagne de connaître ce nouveau clan.
        Campaign.Current.Clans.Add(newClan);
        InformationManager.DisplayMessage(new InformationMessage("Nouveau clan créé : " + clanName));

        return newClan;

    public static void GenerateClanAndMembers(string clanName, Hero leader, Kingdom kingdom, int numberOfMembers)
    {
        // Création du clan
        Clan clan = ClanCreator.CreateNewClan(clanName, leader, kingdom);

        // Génération des membres génériques et assignation au clan
        ClanMemberGenerator.GenerateGenericMembers(clan, numberOfMembers);
    }

    }
}

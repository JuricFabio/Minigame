using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cry_for_Combat
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Created by Fabio Juric on March 17th, 2020. Last Edit - 03/19/2020
             */
            #region Variables
            int userMaxHP = 10;
            int userHP = 10;
            int userMaxDmg = 3;
            int userMinDmg = 0;
            int monsterHP = 6;
            int monsterMaxDmg = 3;
            int monsterMinDmg = 0;
            int userCritChance = 90;
            int monsterCritChance = 95;
            string monsterName;
            bool storyflagTavernExit = false;
            bool storyflagLanturnBonus = false;
            bool storyflagSneakBonus = false;
            bool storyflagTavernTravelEast = false;
            #endregion

            #region Intro Sequence
            Console.WriteLine("You wake up in a tavern, quite groggy, you can't seem to remember much");
            Console.WriteLine("A man approaches you slowly after seeing you wake");
            Console.WriteLine("You can't seem to remember, now would be the perfect time to live the life you wanted");
            Console.WriteLine();
            Console.WriteLine("What is your name?");
            Console.WriteLine();
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("In this adventure, there will be repercussions for each of your actions.");
            Console.WriteLine("Stray from your path and you may find yourself in trouble.");
            Console.WriteLine();
            Console.WriteLine($"{$"Do you understand {username}?", 20:F} {"||   Yes or No   ||", 20:F}");
            Console.WriteLine();
            string introChoice = Console.ReadLine().ToLower();
            Console.WriteLine();
            #endregion

            #region First Choice
            if (introChoice.Substring(0, 1) == "y")
            {
                Console.WriteLine("Perfect. To reward your patience, we will provide you with some weaponry.");
                Console.WriteLine("      -- the bearded man hands you a bronze sword and shield --");
                Console.WriteLine();
                userMaxHP += 5;
                userHP += 5;
                userMaxDmg += 2;
            }
            else
            {
                Console.WriteLine("   Then prepare for a troublesome journey. The old man snaps his fingers and");
                Console.WriteLine("two guards blindfold you. You find yourself in a locked room with a gate");
                Console.WriteLine("peering at you from the other side. It slowly raises to reveal a rabid wolf");
                Console.WriteLine("crawling towards you. You prepare yourself for combat.");
                Console.WriteLine();

                monsterName = "wolf";

                if (singleCombat(ref userHP, monsterHP, userCritChance, monsterCritChance, userMaxDmg, monsterMaxDmg, userMinDmg, monsterMinDmg, userMaxHP, monsterName))
                {
                    Console.WriteLine("==========");
                    Console.WriteLine("You lived!");
                    Console.WriteLine("==========");
                    Console.WriteLine();
                    Console.WriteLine("You've grown stronger in this life or death situation. The man approaches you, quite impressed.");
                    Console.WriteLine("Now you understand the consequenses of your actions. Now, no time for rest. Get up.");
                    Console.WriteLine();
                    userMaxDmg += 4;
                    userMaxHP++;
                    userHP++;
                }
                else
                {
                    Console.WriteLine("=========");
                    Console.WriteLine("You died.");
                    Console.WriteLine("=========");
                    return;
                }
            }
            #endregion

            #region First Adventure
            Console.WriteLine();
            Console.WriteLine("                ACT 1 : Torn Between Two Kingdoms");
            Console.WriteLine();
            Console.WriteLine("A messenger that frequented our tavern has gone missing all of the sudden.");
            Console.WriteLine("We are currently short-handed due to the war between the neighboring kingdoms");
            Console.WriteLine("We need you to travel down South and see if you can manage to find him, and");
            Console.WriteLine("collect his parsels. We heard he was carrying a letter of great importance.");
            Console.WriteLine("We will reward you handsomely for this. Please, we cannot leave the Squeaky Boot Tavern alone");
            Console.WriteLine();
            Console.WriteLine("You are slowly coaxed out of the tavern and see a weathered sign post. As you approach it you notice");
            Console.WriteLine("the writing on the sign.    ||===============================================||");
            Console.WriteLine("                            ||  Niffelheim : North          Landfall : South ||");
            Console.WriteLine("                            ||===============================================||");
            Console.WriteLine();
            Console.WriteLine("Where will you travel?");
            Console.WriteLine();
            #endregion

            while (storyflagTavernExit == false)
            {
                // Test Line to check stats
                Console.WriteLine($"You have {userMaxDmg} max dmg, {userMinDmg} min dmg, {userHP} hp, {userMaxHP} max hp");
                Console.WriteLine();
                // Be sure to edit this line out
                string travelDirectionFromTavern = Console.ReadLine().ToLower().Substring(0, 1);
                Console.WriteLine();

                if (travelDirectionFromTavern == "n")
                {

                }
                else if (travelDirectionFromTavern == "s")
                {

                }
                else if (travelDirectionFromTavern == "w")
                {

                }
                else if (travelDirectionFromTavern == "e")
                {
                    if (storyflagTavernTravelEast == false)
                    {
                        Console.WriteLine("Upon setting out on your journey through the field east. You collect an uneasy feeling that something");
                        Console.WriteLine("is watching you in the distance. As the Squeaky Boot fall out a sight a rustling in the grass behind you");
                        Console.WriteLine("alerts you to that direction. A goblin seems to have followed you out to the field! It begins to charge you!");
                        Console.WriteLine();

                        monsterName = "goblin";

                        if (singleCombat(ref userHP, 15, userCritChance, 90, userMaxDmg, 8, userMinDmg, 2, userMaxHP, monsterName))
                        {
                            Console.WriteLine("==========");
                            Console.WriteLine("You lived!");
                            Console.WriteLine("==========");
                            Console.WriteLine();
                            Console.WriteLine("Bruised and battered from the encounter, you make you way towards the Squeaky Boot.");
                            Console.WriteLine("You take a breath and recollect yourself. Deciding where your next direction should be.");
                            Console.WriteLine();
                            userMaxDmg += 4;
                            userMinDmg += 2;
                            storyflagTavernTravelEast = true;
                        }
                        else
                        {
                            Console.WriteLine("=========");
                            Console.WriteLine("You died.");
                            Console.WriteLine("=========");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("After surviving that encounter, you're unsure if you want to travel further east");
                        Console.WriteLine();
                    }
                }
                else if (travelDirectionFromTavern == "+")
                {
                    storychoiceTavernCheat(ref storyflagSneakBonus, ref userMinDmg, ref userMaxDmg, ref userCritChance);
                }
                else
                {
                    storychoiceTavernBlank(ref storyflagLanturnBonus, ref userMaxDmg);
                }
            }

            // Test Line to check stats
            Console.WriteLine($"You have {userMaxDmg} max dmg, {userMinDmg} min dmg, {userHP} hp, {userMaxHP} max hp");
            // Be sure to edit this line out
        }
        public static void storychoiceTavernCheat(ref bool storyflagSneakBonus, ref int userMinDmg, ref int userMaxDmg, ref int userCritChance)
        {
            if (storyflagSneakBonus == false)
            {
                Console.WriteLine("Congrats on reading the code asshole. Lets make things easy for you since that's what you want");
                Console.WriteLine();
                userMinDmg += 2;
                userMaxDmg += 2;
                userCritChance = userCritChance - 5;
                storyflagSneakBonus = true;
            }
            else
            {
                Console.WriteLine("Fuck you, get out of here");
                Console.WriteLine();
            }
        }
        public static void storychoiceTavernBlank(ref bool storyflagLanturnBonus, ref int userMaxDmg)
        {
            if (storyflagLanturnBonus == false)
            {
                Console.WriteLine("You decide to wander aimlessly in hope of stumbling upon an abandoned camp. As night falls a light");
                Console.WriteLine("shines in the distance and you decide to follow it. As you get closer, you notice a lanturn, swaying");
                Console.WriteLine("swaying in the wind. You become entranced and and commit to your direction. You reach a small camp and");
                Console.WriteLine("find a strange hooded man reaching his hands over a fire. He raises his head and looks over in your");
                Console.WriteLine("direction. Bright blank white eyes stare at you and you feel paralyzed. A voice echoes in your head.");
                Console.WriteLine("You black out and find yourself outside the Squeaky Boot. You feel as if your muscle mass has weakened.");
                Console.WriteLine();
                userMaxDmg = userMaxDmg - 2;
                storyflagLanturnBonus = true;
            }
            else
            {
                Console.WriteLine("You feel as though you should not wander around once again.");
                Console.WriteLine();
            }
        }
        public static bool singleCombat(ref int userHP, int monsterHP, int userCritChance, int monsterCritChance, int userMaxDmg, int monsterMaxDmg, int userMinDmg, int monsterMinDmg, int userMaxHP, string monsterName)
        {
            string userActions = $"Attack || Heal || Observe";
            int playerDmg;
            int monsterDmg;
            int playerCrit;
            int monsterCrit;

            while (userHP > 0 && monsterHP > 0)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(userActions);
                Console.WriteLine("=========================");
                Console.WriteLine();
                string combatSelection = Console.ReadLine().Substring(0, 1).ToLower();
                Console.WriteLine();

                if (combatSelection == "a")
                {
                    Random randomizer = new Random();
                    playerDmg = randomizer.Next(userMinDmg, userMaxDmg);

                    Random crit1 = new Random();
                    playerCrit = randomizer.Next(0, 101);

                    if (playerDmg > 0)
                    {
                        if (playerCrit >= userCritChance && playerCrit <= 100)
                        {
                            monsterHP = monsterHP - (playerDmg * 2);
                            Console.WriteLine($"You strike the {monsterName} dealing {playerDmg * 2} damage! A Critical Hit!");
                            Console.WriteLine();
                        }
                        else
                        {
                            monsterHP = monsterHP - playerDmg;
                            Console.WriteLine($"You strike the {monsterName} dealing {playerDmg} damage!");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"You strike at the {monsterName} and miss!");
                        Console.WriteLine();
                    }

                    if (monsterHP > 0)
                    {
                        Random randomizer1 = new Random();
                        monsterDmg = randomizer.Next(monsterMinDmg, monsterMaxDmg);

                        Random crit2 = new Random();
                        monsterCrit = randomizer.Next(0, 101);

                        if (monsterDmg > 0)
                        {
                            if (monsterCrit >= monsterCritChance && monsterCrit <= 100)
                            {
                                userHP = userHP - (monsterDmg * 2);
                                Console.WriteLine($"The {monsterName} deals {monsterDmg * 2} damage! A Critical Hit!");
                                Console.WriteLine();
                            }
                            else
                            {
                                userHP = userHP - monsterDmg;
                                Console.WriteLine($"The {monsterName} deals {monsterDmg} damage!");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"The {monsterName} lashes at you and misses!");
                        }
                    }
                }
                else if (combatSelection == "h")
                {
                    int healing;

                    Random randomizer = new Random();
                    healing = randomizer.Next(1, (userMaxHP / 2));

                    userHP = userHP + healing;

                    if (userHP > userMaxHP)
                    {
                        userHP = userMaxHP;
                    }

                    Console.WriteLine($"You've healed {healing} HP, leaving yourself at {userHP} HP.");
                    Console.WriteLine();

                    Random randomizer1 = new Random();
                    monsterDmg = randomizer.Next(monsterMinDmg, monsterMaxDmg);

                    Random crit2 = new Random();
                    monsterCrit = randomizer.Next(0, 101);

                    if (monsterDmg > 0)
                    {
                        if (monsterCrit >= monsterCritChance && monsterCrit <= 100)
                        {
                            userHP = userHP - (monsterDmg * 2);
                            Console.WriteLine($"The {monsterName} deals {monsterDmg * 2} damage! A Critical Hit!");
                            Console.WriteLine();
                        }
                        else
                        {
                            userHP = userHP - monsterDmg;
                            Console.WriteLine($"The {monsterName} deals {monsterDmg} damage!");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"The {monsterName} lashes at you and misses!");
                    }
                }
                else
                {
                    Console.WriteLine($"The {monsterName} has {monsterHP} HP remaining. You have {userHP} HP remaining");
                    Console.WriteLine();
                }
            }
            if (monsterHP <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

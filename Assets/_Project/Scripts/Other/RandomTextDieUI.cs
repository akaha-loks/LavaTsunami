using TMPro;
using UnityEngine;
using YG.Example;

public class RandomTextDieUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private string[] _quotesRus =
    {
        " ирку потер€л, дом забыл где построил Ч классика жанра",
        "¬ышел покопать уголь, вернулс€ с трем€ стаками булыжника и экзистенциальным кризисом",
        "—троил дворец, получилось что-то между туалетом и хижиной ведьмы",
        "«ачем мне жизнь, если у мен€ нет алмазов",
        "ќдин  рипер Ч случайность, три  рипера за спиной Ч уже вечеринка",
        "ѕроголодалс€, поел гнилой плоти Ч выжил, доволен, игра гениальна",
        "»грал с другом Ч потер€лись, обвинили друг друга, подожгли деревню. ¬есело было",
        "ƒумал зайду на п€ть минут... шесть часов спуст€, у мен€ уже ферма коров и философские размышлени€ о вечном",
        "ѕостроил башню до неба, упал, заплакал, но горжусь",
        "¬ ћайнкрафт € бог, пока не по€вилс€ скелет с аимом"
    };
    private string[] _quotesEng =
    {
        "Lost my pickaxe, forgot where I built my house Ч classic Minecraft experience",
        "Went to mine some coal, came back with three stacks of cobblestone and an existential crisis",
        "Tried to build a palace, ended up with something between a toilet and a witch's hut",
        "What's the point of life if I don't have diamonds?",
        "One Creeper is bad luck, three behind you Ч that's a party",
        "Got hungry, ate rotten flesh, survived Ч 10/10 game",
        "Played with a friend Ч got lost, blamed each other, burned down a village. Good times",
        "Thought IТd play for five minutes... six hours later, I have a cow farm and deep philosophical thoughts",
        "Built a tower to the sky, fell off, cried a bit Ч still proud",
        "In Minecraft I'm a god, until a skeleton with aimbot shows up"
    };


    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.GetString("lang") == "en")
            _text.text = _quotesEng[Random.Range(0, 10)];
        else
            _text.text = _quotesRus[Random.Range(0, 10)];
    }
}

using TMPro;
using UnityEngine;
using YG.Example;

public class RandomTextDieUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private string[] _quotesRus =
    {
        "����� �������, ��� ����� ��� �������� � �������� �����",
        "����� �������� �����, �������� � ����� ������� ��������� � ���������������� ��������",
        "������ ������, ���������� ���-�� ����� �������� � ������� ������",
        "����� ��� �����, ���� � ���� ��� �������",
        "���� ������ � �����������, ��� ������� �� ������ � ��� ���������",
        "������������, ���� ������ ����� � �����, �������, ���� ���������",
        "����� � ������ � ����������, �������� ���� �����, �������� �������. ������ ����",
        "����� ����� �� ���� �����... ����� ����� ������, � ���� ��� ����� ����� � ����������� ����������� � ������",
        "�������� ����� �� ����, ����, ��������, �� �������",
        "� ��������� � ���, ���� �� �������� ������ � �����"
    };
    private string[] _quotesEng =
    {
        "Lost my pickaxe, forgot where I built my house � classic Minecraft experience",
        "Went to mine some coal, came back with three stacks of cobblestone and an existential crisis",
        "Tried to build a palace, ended up with something between a toilet and a witch's hut",
        "What's the point of life if I don't have diamonds?",
        "One Creeper is bad luck, three behind you � that's a party",
        "Got hungry, ate rotten flesh, survived � 10/10 game",
        "Played with a friend � got lost, blamed each other, burned down a village. Good times",
        "Thought I�d play for five minutes... six hours later, I have a cow farm and deep philosophical thoughts",
        "Built a tower to the sky, fell off, cried a bit � still proud",
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

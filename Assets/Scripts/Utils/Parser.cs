using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEditor.Animations;
using UnityEngine;

public class Parser
{

    public Dictionary<int, DialogContainer> _dialogs;

    public class DialogContainer
    {
        public int id;
        public String interlocutor;
        public String text;
        public Dictionary<int, pair> choicesDictionary;

        public DialogContainer(int id, string interlocutor, string text, Dictionary<int, pair> choicesDictionary)
        {
            this.id = id;
            this.interlocutor = interlocutor;
            this.text = text;
            this.choicesDictionary = choicesDictionary;
        }
    }


    public Dictionary<int, DialogContainer> parse(JToken source)
    {
        Dictionary<int, DialogContainer> dict = new Dictionary<int, DialogContainer>();
        var children = source["Dialogs"].Children();
        foreach (var child in children)
        {
            var choices = new Dictionary<int, pair>();
            var i = 1;
            foreach (var choice in child["Choices"].Children())
            {
                choices.Add(i, new pair(choice[i.ToString()].Value<int>("ID"),choice[i.ToString()].Value<string>("text")));
                i++;
            }
            dict.Add(child.Value<int>("ID"), new DialogContainer(child.Value<int>("ID"), child.Value<string>("Interlocutor"), child.Value<string>("Text"), choices));
        }
        return dict;
    }

    public class pair
    {
        public pair(int id, string text)
        {
            this.id = id;
            this.text = text;
        }

        public int id;
        public string text;
    }

    public Parser(JToken source)
    {
        _dialogs = parse(source);
    }
}

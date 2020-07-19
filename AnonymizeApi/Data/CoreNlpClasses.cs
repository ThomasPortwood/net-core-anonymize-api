using System;
using System.Collections.Generic;

namespace AnonymizeApi.Data
{
    public class Entitymention
    {
        public int docTokenBegin { get; set; }
        public int docTokenEnd { get; set; }
        public int tokenBegin { get; set; }
        public int tokenEnd { get; set; }
        public string text { get; set; }
        public int characterOffsetBegin { get; set; }
        public int characterOffsetEnd { get; set; }
        public string ner { get; set; }
    }

    public class Token
    {
        public int index { get; set; }
        public string word { get; set; }
        public string originalText { get; set; }
        public string lemma { get; set; }
        public int characterOffsetBegin { get; set; }
        public int characterOffsetEnd { get; set; }
        public string pos { get; set; }
        public string ner { get; set; }
        public string before { get; set; }
        public string after { get; set; }
    }

    public class Sentence
    {
        public int index { get; set; }
        public List<Entitymention> entitymentions { get; set; }
        public List<Token> tokens { get; set; }
    }

    public class Root
    {
        public DateTime docDate { get; set; }
        public List<Sentence> sentences { get; set; }
    }
}
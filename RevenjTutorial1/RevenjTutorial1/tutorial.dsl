module Tutorial {
  aggregate Example {
    timestamp StartedOn;
    string CodeName;
    Set<string(10)> Tags;
    List<Idea> Ideas;
    persistence { history; }
  }
  value Idea {
    date? ETA;
    Importance Rating;
    decimal Probability;
    string[] Notes;
  }
  enum Importance {
    NotUseful;
    GroundBreaking;
    WorldChanging;
  }
  snowflake<Example> ExampleList {
    StartedOn;
    CodeName;
    order by StartedOn desc;
  }
}
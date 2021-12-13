namespace Advent2021.SubmarineSystems;

public class CaveMapper
{
    private readonly ILogger<CaveMapper> _logger;

    private const string Start = "start";
    private const string End = "end";

    private int _pathCount;
    private List<string> _pathNodes;
    private bool _hasUsedTwice;
    private Dictionary<string, List<string>> _caveConnections;

    public CaveMapper(ILogger<CaveMapper> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public int GetPathsThroughCave(List<string> paths)
    {
        MapCaveConnections(paths);
        var answer = GetPathsThroughCave();
        _logger.LogCritical(
            "How many paths through this cave system are there that visit small caves at most once? Answer: {Answer}",
            answer);
        return answer;
    }

    public int GetPathsThroughCaveSmallCavesTwice(List<string> paths)
    {
        MapCaveConnections(paths);
        var answer = GetPathsThroughCave(true);
        _logger.LogCritical(
            "How many paths through this cave system are there that visit small caves twice? Answer: {Answer}",
            answer);
        return answer;
    }

    private int GetPathsThroughCave(bool allowTwice = false)
    {
        _pathNodes = new List<string>();
        _hasUsedTwice = false;
        _pathCount = 0;
        Dfs(Start, allowTwice);
        return _pathCount;
    }

    private void Dfs(string cave, bool allowTwice = false)
    {
        switch (cave)
        {
            case End:
                _pathCount++;
                return;
            case Start when _pathNodes.Count > 0:
                return;
        }

        var isUpper = char.IsUpper(cave[0]);
        var storeUsedTwice = _hasUsedTwice;

        if (!isUpper && _pathNodes.Contains(cave))
        {
            if (allowTwice)
            {
                if (_hasUsedTwice) return;
                _hasUsedTwice = true;
            } else
            {
                return;
            }
        }

        _pathNodes.Add(cave);
        foreach (var connection in _caveConnections[cave]) Dfs(connection, allowTwice);
        _pathNodes.RemoveAt(_pathNodes.Count - 1);
        _hasUsedTwice = storeUsedTwice;
    }

    private void MapCaveConnections(List<string> paths)
    {
        _caveConnections = new Dictionary<string, List<string>>();
        foreach (var path in paths)
        {
            var caves = path.Split("-");
            var cave1 = caves.First();
            var cave2 = caves.Last();
            if (!_caveConnections.ContainsKey(cave1))
            {
                _caveConnections.Add(cave1, new List<string> { cave2 });
            }
            else
            {
                if (!_caveConnections[cave1].Exists(c => c == cave2))
                {
                    _caveConnections[cave1].Add(cave2);
                }
            }

            if (!_caveConnections.ContainsKey(cave2))
            {
                _caveConnections.Add(cave2, new List<string> { cave1 });
            }
            else
            {
                if (!_caveConnections[cave2].Exists(c => c == cave1))
                {
                    _caveConnections[cave2].Add(cave1);
                }
            }
        }
    }
}

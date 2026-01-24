/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Look up current cell's allowed moves (left, right, up, down).
        var moves = _mazeMap[(_currX, _currY)];
        // Index 0 corresponds to moving left.
        if (!moves[0])
        {
            // A wall is present on the left.
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update position by decreasing x to move left.
        _currX -= 1;
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Look up current cell's allowed moves (left, right, up, down).
        var moves = _mazeMap[(_currX, _currY)];
        // Index 1 corresponds to moving right.
        if (!moves[1])
        {
            // A wall is present on the right.
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update position by increasing x to move right.
        _currX += 1;
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Look up current cell's allowed moves (left, right, up, down).
        var moves = _mazeMap[(_currX, _currY)];
        // Index 2 corresponds to moving up.
        if (!moves[2])
        {
            // A wall is present above.
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update position by decreasing y to move up.
        _currY -= 1;
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Look up current cell's allowed moves (left, right, up, down).
        var moves = _mazeMap[(_currX, _currY)];
        // Index 3 corresponds to moving down.
        if (!moves[3])
        {
            // A wall is present below.
            throw new InvalidOperationException("Can't go that way!");
        }

        // Update position by increasing y to move down.
        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
﻿namespace Wobble.Graphics
{
    /// <summary>
    ///     2 Dimensional ScalableVector
    /// </summary>
    public struct ScalableVector2
    {
        /// <summary>
        ///    The X value
        /// </summary>
        public ScalableVector X { get; }

        /// <summary>
        ///     The y value.
        /// </summary>
        public ScalableVector Y { get; }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="xVal"></param>
        /// <param name="yVal"></param>
        /// <param name="xScale"></param>
        /// <param name="yScale"></param>
        public ScalableVector2(float xVal, float yVal, float xScale = 0, float yScale = 0)
        {
            X = new ScalableVector(xVal, xScale);
            Y = new ScalableVector(yVal, yScale);
        }

        public override string ToString() => $"X: {X}, Y: {Y}";
    }
}
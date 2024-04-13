/*
 * StabilityAi/Types.cs
 * Defines the 'StabilityAiRequestParameters' struct used as a request parameter for the Stability Ai API.
 * Joseph Breslin, 2024
 */

using System;
using UnityEngine;

namespace StabilityAi
{
    // Struct used as a request parameter for the Stability Ai API.
    [Serializable]
    public struct StabilityAiRequestParameters
    {
        //Output file name for the generated image should contain the png file extension.
        public string outputFileName;

        // Prompt text for the image generation request should be a string that contains the subject of the image and the desired style.
        public string promptText;

        // Dimensions of the generated image in pixels. Reccomended 512x512.
        public Vector2Int dimensions;

        // Number of samples to use for the image generation. Reccomended 1.
        public int samples;

        // Number of steps to use for the image generation. Reccomended 30.
        public int steps;

        // How accurate is the image to the prompt. Reccomended 7-8.
        public int cfgScale;
    }
}

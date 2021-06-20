﻿using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Services
{
    public class InputService : IInputService
    {
        private InputService() { }
        private static InputService instance = null;
        public static InputService getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputService();
                }
                return instance;
            }
        }
        public Plateau ProcessPlateauInput(string input)
        {
            var result = new int[2];
            var items = input.Trim().Split(' ');
            if (items.Length != 2)
            {
                return null;
            }
            for(int i=0; i<2; i++)
            {
                if (!int.TryParse(items[i], out int value))
                {
                    return null;
                }
                if(value <= 0)
                {
                    return null;
                }
                result[i] = value;
            }
            return new Plateau(result[0], result[1]);
        }

        public Position ProcessRoverCoordinatesInput(string input)
        {
            var result = new int[2];
            var validLetters = new List<string>() { "E", "W", "S", "N" };
            var items = input.Trim().ToUpper().Split(' ');
            if (items.Length != 3)
            {
                return null;
            }
            for (int i = 0; i < 2; i++)
            {
                if (!int.TryParse(items[i], out int value))
                {
                    return null;
                }
                if(value < 0)
                {
                    return null;
                }
                result[i] = value;
            }
            if (!validLetters.Contains(items[2]))
            {
                return null;
            }
            return new Position( result[0], result[1], (int)Enum.Parse(typeof(Compass), items[2]) );
        }

        public string IsRoversExplorationPathInputValid(string explorationMapInput)
        {
            if (string.IsNullOrWhiteSpace(explorationMapInput) || string.IsNullOrEmpty(explorationMapInput))
            {
                return null;
            }
            var preparedInput = explorationMapInput.Trim().ToUpper();
            var validLetters = new List<string>() { "L", "R", "M" };
            foreach (var ch in preparedInput.ToCharArray())
            {
                if (!validLetters.Contains(ch.ToString()))
                {
                    return null;
                }
            }
            return preparedInput;
        }
    }
}

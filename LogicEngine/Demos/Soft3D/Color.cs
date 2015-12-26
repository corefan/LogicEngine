﻿//==============================================================================
// Copyright (C) 2015 Peng Guang Hui
// All rights reserved
//
// Create by 彭光辉 at 2015/10/16 20:30:00
// Email: gh.peng@qq.com
//==============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using LogicEngine;

namespace Demos.Soft3D
{
    /// <summary>
    ///   <para>Representation of RGBA colors.</para>
    /// </summary>
    public struct Color
    {
        /// <summary>
        ///   <para>Red component of the color.</para>
        /// </summary>
        public float r;

        /// <summary>
        ///   <para>Green component of the color.</para>
        /// </summary>
        public float g;

        /// <summary>
        ///   <para>Blue component of the color.</para>
        /// </summary>
        public float b;

        /// <summary>
        ///   <para>Alpha component of the color.</para>
        /// </summary>
        public float a;

        /// <summary>
        ///   <para>Solid red. RGBA is (1, 0, 0, 1).</para>
        /// </summary>
        public static Color red
        {
            get
            {
                return new Color(1f, 0f, 0f, 1f);
            }
        }

        /// <summary>
        ///   <para>Solid green. RGBA is (0, 1, 0, 1).</para>
        /// </summary>
        public static Color green
        {
            get
            {
                return new Color(0f, 1f, 0f, 1f);
            }
        }

        /// <summary>
        ///   <para>Solid blue. RGBA is (0, 0, 1, 1).</para>
        /// </summary>
        public static Color blue
        {
            get
            {
                return new Color(0f, 0f, 1f, 1f);
            }
        }

        /// <summary>
        ///   <para>Solid white. RGBA is (1, 1, 1, 1).</para>
        /// </summary>
        public static Color white
        {
            get
            {
                return new Color(1f, 1f, 1f, 1f);
            }
        }

        /// <summary>
        ///   <para>Solid black. RGBA is (0, 0, 0, 1).</para>
        /// </summary>
        public static Color black
        {
            get
            {
                return new Color(0f, 0f, 0f, 1f);
            }
        }

        /// <summary>
        ///   <para>Yellow. RGBA is (1, 0.92, 0.016, 1), but the color is nice to look at!</para>
        /// </summary>
        public static Color yellow
        {
            get
            {
                return new Color(1f, 0.921568632f, 0.0156862754f, 1f);
            }
        }

        /// <summary>
        ///   <para>Cyan. RGBA is (0, 1, 1, 1).</para>
        /// </summary>
        public static Color cyan
        {
            get
            {
                return new Color(0f, 1f, 1f, 1f);
            }
        }

        /// <summary>
        ///   <para>Magenta. RGBA is (1, 0, 1, 1).</para>
        /// </summary>
        public static Color magenta
        {
            get
            {
                return new Color(1f, 0f, 1f, 1f);
            }
        }

        /// <summary>
        ///   <para>Gray. RGBA is (0.5, 0.5, 0.5, 1).</para>
        /// </summary>
        public static Color gray
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }

        /// <summary>
        ///   <para>English spelling for gray. RGBA is the same (0.5, 0.5, 0.5, 1).</para>
        /// </summary>
        public static Color grey
        {
            get
            {
                return new Color(0.5f, 0.5f, 0.5f, 1f);
            }
        }

        /// <summary>
        ///   <para>Completely transparent. RGBA is (0, 0, 0, 0).</para>
        /// </summary>
        public static Color clear
        {
            get
            {
                return new Color(0f, 0f, 0f, 0f);
            }
        }

        /// <summary>
        ///   <para>The grayscale value of the color. (Read Only)</para>
        /// </summary>
        public float grayscale
        {
            get
            {
                return 0.299f * this.r + 0.587f * this.g + 0.114f * this.b;
            }
        }

        /// <summary>
        ///   <para>A linear value of an sRGB color.</para>
        /// </summary>
        public Color linear
        {
            get
            {
                return new Color(UtilMath.GammaToLinearSpace(this.r), UtilMath.GammaToLinearSpace(this.g), UtilMath.GammaToLinearSpace(this.b), this.a);
            }
        }

        /// <summary>
        ///   <para>A version of the color that has had the gamma curve applied.</para>
        /// </summary>
        public Color gamma
        {
            get
            {
                return new Color(UtilMath.LinearToGammaSpace(this.r), UtilMath.LinearToGammaSpace(this.g), UtilMath.LinearToGammaSpace(this.b), this.a);
            }
        }

        /// <summary>
        ///   <para>Returns the maximum color component value: Max(r,g,b).</para>
        /// </summary>
        public float maxColorComponent
        {
            get
            {
                return UtilMath.Max(UtilMath.Max(this.r, this.g), this.b);
            }
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.r;
                    case 1:
                        return this.g;
                    case 2:
                        return this.b;
                    case 3:
                        return this.a;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.r = value;
                        break;
                    case 1:
                        this.g = value;
                        break;
                    case 2:
                        this.b = value;
                        break;
                    case 3:
                        this.a = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        /// <summary>
        ///   <para>Constructs a new Color with given r,g,b,a components.</para>
        /// </summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        /// <param name="a">Alpha component.</param>
        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        ///   <para>Constructs a new Color with given r,g,b components and sets a to 1.</para>
        /// </summary>
        /// <param name="r">Red component.</param>
        /// <param name="g">Green component.</param>
        /// <param name="b">Blue component.</param>
        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1f;
        }

        /// <summary>
        ///   <para>Returns a nicely formatted string of this color.</para>
        /// </summary>
        /// <param name="format"></param>
        public override string ToString()
        {
            return string.Format("RGBA({0:F3}, {1:F3}, {2:F3}, {3:F3})", new object[]
			{
				this.r,
				this.g,
				this.b,
				this.a
			});
        }

        /// <summary>
        ///   <para>Returns a nicely formatted string of this color.</para>
        /// </summary>
        /// <param name="format"></param>
        public string ToString(string format)
        {
            return string.Format("RGBA({0}, {1}, {2}, {3})", new object[]
			{
				this.r.ToString(format),
				this.g.ToString(format),
				this.b.ToString(format),
				this.a.ToString(format)
			});
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (!(other is Color))
            {
                return false;
            }
            Color color = (Color)other;
            return this.r.Equals(color.r) && this.g.Equals(color.g) && this.b.Equals(color.b) && this.a.Equals(color.a);
        }

        /// <summary>
        ///   <para>Linearly interpolates between colors a and b by t.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        public static Color Lerp(Color a, Color b, float t)
        {
            t = UtilMath.Clamp01(t);
            return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
        }

        /// <summary>
        ///   <para>Linearly interpolates between colors a and b by t.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        public static Color LerpUnclamped(Color a, Color b, float t)
        {
            return new Color(a.r + (b.r - a.r) * t, a.g + (b.g - a.g) * t, a.b + (b.b - a.b) * t, a.a + (b.a - a.a) * t);
        }

        internal Color RGBMultiplied(float multiplier)
        {
            return new Color(this.r * multiplier, this.g * multiplier, this.b * multiplier, this.a);
        }

        internal Color AlphaMultiplied(float multiplier)
        {
            return new Color(this.r, this.g, this.b, this.a * multiplier);
        }

        internal Color RGBMultiplied(Color multiplier)
        {
            return new Color(this.r * multiplier.r, this.g * multiplier.g, this.b * multiplier.b, this.a);
        }

        public static void RGBToHSV(Color rgbColor, out float H, out float S, out float V)
        {
            if (rgbColor.b > rgbColor.g && rgbColor.b > rgbColor.r)
            {
                Color.RGBToHSVHelper(4f, rgbColor.b, rgbColor.r, rgbColor.g, out H, out S, out V);
            }
            else if (rgbColor.g > rgbColor.r)
            {
                Color.RGBToHSVHelper(2f, rgbColor.g, rgbColor.b, rgbColor.r, out H, out S, out V);
            }
            else
            {
                Color.RGBToHSVHelper(0f, rgbColor.r, rgbColor.g, rgbColor.b, out H, out S, out V);
            }
        }

        private static void RGBToHSVHelper(float offset, float dominantcolor, float colorone, float colortwo, out float H, out float S, out float V)
        {
            V = dominantcolor;
            if (V != 0f)
            {
                float num;
                if (colorone > colortwo)
                {
                    num = colortwo;
                }
                else
                {
                    num = colorone;
                }
                float num2 = V - num;
                if (num2 != 0f)
                {
                    S = num2 / V;
                    H = offset + (colorone - colortwo) / num2;
                }
                else
                {
                    S = 0f;
                    H = offset + (colorone - colortwo);
                }
                H /= 6f;
                if (H < 0f)
                {
                    H += 1f;
                }
            }
            else
            {
                S = 0f;
                H = 0f;
            }
        }

        /// <summary>
        ///   <para>Creates an RGB colour from HSV input.</para>
        /// </summary>
        /// <param name="H">Hue [0..1].</param>
        /// <param name="S">Saturation [0..1].</param>
        /// <param name="V">Value [0..1].</param>
        /// <param name="hdr">Output HDR colours. If true, the returned colour will not be clamped to [0..1].</param>
        /// <returns>
        ///   <para>An opaque colour with HSV matching the input.</para>
        /// </returns>
        public static Color HSVToRGB(float H, float S, float V)
        {
            return Color.HSVToRGB(H, S, V, true);
        }

        /// <summary>
        ///   <para>Creates an RGB colour from HSV input.</para>
        /// </summary>
        /// <param name="H">Hue [0..1].</param>
        /// <param name="S">Saturation [0..1].</param>
        /// <param name="V">Value [0..1].</param>
        /// <param name="hdr">Output HDR colours. If true, the returned colour will not be clamped to [0..1].</param>
        /// <returns>
        ///   <para>An opaque colour with HSV matching the input.</para>
        /// </returns>
        public static Color HSVToRGB(float H, float S, float V, bool hdr)
        {
            Color white = Color.white;
            if (S == 0f)
            {
                white.r = V;
                white.g = V;
                white.b = V;
            }
            else if (V == 0f)
            {
                white.r = 0f;
                white.g = 0f;
                white.b = 0f;
            }
            else
            {
                white.r = 0f;
                white.g = 0f;
                white.b = 0f;
                float num = H * 6f;
                int num2 = (int)UtilMath.Floor(num);
                float num3 = num - (float)num2;
                float num4 = V * (1f - S);
                float num5 = V * (1f - S * num3);
                float num6 = V * (1f - S * (1f - num3));
                int num7 = num2;
                switch (num7 + 1)
                {
                    case 0:
                        white.r = V;
                        white.g = num4;
                        white.b = num5;
                        break;
                    case 1:
                        white.r = V;
                        white.g = num6;
                        white.b = num4;
                        break;
                    case 2:
                        white.r = num5;
                        white.g = V;
                        white.b = num4;
                        break;
                    case 3:
                        white.r = num4;
                        white.g = V;
                        white.b = num6;
                        break;
                    case 4:
                        white.r = num4;
                        white.g = num5;
                        white.b = V;
                        break;
                    case 5:
                        white.r = num6;
                        white.g = num4;
                        white.b = V;
                        break;
                    case 6:
                        white.r = V;
                        white.g = num4;
                        white.b = num5;
                        break;
                    case 7:
                        white.r = V;
                        white.g = num6;
                        white.b = num4;
                        break;
                }
                if (!hdr)
                {
                    white.r = UtilMath.Clamp(white.r, 0f, 1f);
                    white.g = UtilMath.Clamp(white.g, 0f, 1f);
                    white.b = UtilMath.Clamp(white.b, 0f, 1f);
                }
            }
            return white;
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        }

        public static Color operator *(Color a, float b)
        {
            return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        }

        public static Color operator *(float b, Color a)
        {
            return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        }

        public static Color operator /(Color a, float b)
        {
            return new Color(a.r / b, a.g / b, a.b / b, a.a / b);
        }

        public static bool operator ==(Color lhs, Color rhs)
        {
            return lhs == rhs;
        }

        public static bool operator !=(Color lhs, Color rhs)
        {
            return !(lhs == rhs);
        }

        public static implicit operator Vector4f(Color c)
        {
            return new Vector4f(c.r, c.g, c.b, c.a);
        }

        public static implicit operator Color(Vector4f v)
        {
            return new Color(v.x, v.y, v.z, v.w);
        }
    }
}
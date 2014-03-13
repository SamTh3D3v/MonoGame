// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Diagnostics;
using Sce.PlayStation.Core.Graphics;

namespace Microsoft.Xna.Framework.Graphics
{
    public partial class BlendState
    {
        internal void PlatformApplyState(GraphicsDevice device)
        {
            var blendEnabled = !(this.ColorSourceBlend == Blend.One && 
                                 this.ColorDestinationBlend == Blend.Zero &&
                                 this.AlphaSourceBlend == Blend.One &&
                                 this.AlphaDestinationBlend == Blend.Zero);
            if (blendEnabled)
                GL.Enable(EnableCap.Blend);
            else
                GL.Disable(EnableCap.Blend);
            GraphicsExtensions.CheckGLError();

            GL.BlendColor(
                this.BlendFactor.R / 255.0f,      
                this.BlendFactor.G / 255.0f, 
                this.BlendFactor.B / 255.0f, 
                this.BlendFactor.A / 255.0f);
            GraphicsExtensions.CheckGLError();

            GL.BlendEquationSeparate(
                this.ColorBlendFunction.GetBlendEquationMode(),
                this.AlphaBlendFunction.GetBlendEquationMode());
            GraphicsExtensions.CheckGLError();

            GL.BlendFuncSeparate(
                this.ColorSourceBlend.GetBlendFactorSrc(), 
                this.ColorDestinationBlend.GetBlendFactorDest(), 
                this.AlphaSourceBlend.GetBlendFactorSrc(), 
                this.AlphaDestinationBlend.GetBlendFactorDest());
            GraphicsExtensions.CheckGLError();

            GL.ColorMask(
                (this.ColorWriteChannels & ColorWriteChannels.Red) != 0,
                (this.ColorWriteChannels & ColorWriteChannels.Green) != 0,
                (this.ColorWriteChannels & ColorWriteChannels.Blue) != 0,
                (this.ColorWriteChannels & ColorWriteChannels.Alpha) != 0);
            GraphicsExtensions.CheckGLError();
        }

        private void PlatformDispose()
        {
        }
	}
}


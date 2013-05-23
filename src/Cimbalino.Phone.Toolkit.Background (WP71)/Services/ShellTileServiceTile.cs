﻿// ****************************************************************************
// <copyright file="ShellTileServiceTile.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2013
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>21-05-2013</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using Microsoft.Phone.Shell;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IShellTileServiceTile"/>.
    /// </summary>
    public class ShellTileServiceTile : IShellTileServiceTile
    {
        private readonly ShellTile _shellTile;

        #region Properties

        /// <summary>
        /// Gets the <see cref="Uri"/> and launch parameter this is navigated to when a secondary tile is tapped.
        /// </summary>
        /// <value>The <see cref="Uri"/> and launch parameter this is navigated to when a secondary tile is tapped.</value>
        public Uri NavigationUri
        {
            get
            {
                return _shellTile.NavigationUri;
            }
        }

        #endregion

        internal ShellTileServiceTile(ShellTile shellTile)
        {
            _shellTile = shellTile;
        }

        /// <summary>
        /// Updates an Application Tile or secondary Tile.
        /// </summary>
        /// <param name="data">New text and image data for the tile.</param>
        public void Update(IShellTileServiceTileData data)
        {
            var shellTileServiceTileDataBase = data as ShellTileServiceTileDataBase;

            if (shellTileServiceTileDataBase == null)
            {
                throw new ArgumentException("A ShellTileServiceTileDataBase instance is expected.", "data");
            }

            _shellTile.Update(shellTileServiceTileDataBase.ToShellTileData());
        }

        /// <summary>
        /// Unpins and deletes a secondary tile.
        /// </summary>
        public void Delete()
        {
            _shellTile.Delete();
        }
    }
}
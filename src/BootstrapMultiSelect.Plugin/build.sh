#!/bin/bash
# Build script for Bootstrap MultiSelect Plugin
# This script copies source files and prepares the distribution package

echo "Building Bootstrap MultiSelect Plugin..."

# Define paths
SCRIPT_DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
MVC_WWWROOT="$SCRIPT_DIR/../BootstrapMultiSelect.MVC/wwwroot"
SRC_DIR="$SCRIPT_DIR/src"
DIST_DIR="$SCRIPT_DIR/dist"

# Clean dist directory
echo "Cleaning dist directory..."
if [ -d "$DIST_DIR" ]; then
    rm -rf "$DIST_DIR"/*
fi

# Create dist directories
mkdir -p "$DIST_DIR/js"
mkdir -p "$DIST_DIR/css"
mkdir -p "$DIST_DIR/langs"

# Copy JavaScript files
echo "Copying JavaScript files..."
cp "$MVC_WWWROOT/js/bootstrap-multiselect.js" "$DIST_DIR/js/"
cp "$MVC_WWWROOT/js/bootstrap-multiselect.min.js" "$DIST_DIR/js/"

# Copy to src as well (source files)
mkdir -p "$SRC_DIR/js"
cp "$MVC_WWWROOT/js/bootstrap-multiselect.js" "$SRC_DIR/js/"

# Copy CSS files
echo "Copying CSS files..."
cp "$MVC_WWWROOT/css/bootstrap-multiselect.css" "$DIST_DIR/css/"

# Copy to src as well
mkdir -p "$SRC_DIR/css"
cp "$MVC_WWWROOT/css/bootstrap-multiselect.css" "$SRC_DIR/css/"

# Copy language files
echo "Copying language files..."
cp "$MVC_WWWROOT/langs"/*.js "$DIST_DIR/langs/"

# Copy README.md for language files
if [ -f "$MVC_WWWROOT/langs/README.md" ]; then
    cp "$MVC_WWWROOT/langs/README.md" "$DIST_DIR/langs/"
fi

# Copy non-minified language files to src
mkdir -p "$SRC_DIR/langs"
for file in "$MVC_WWWROOT/langs"/*.js; do
    if [[ ! $file =~ \.min\.js$ ]]; then
        cp "$file" "$SRC_DIR/langs/"
    fi
done

# Copy README.md to src/langs as well
if [ -f "$MVC_WWWROOT/langs/README.md" ]; then
    cp "$MVC_WWWROOT/langs/README.md" "$SRC_DIR/langs/"
fi

echo "Build completed successfully!"
echo ""
echo "Distribution files are in: $DIST_DIR"
echo "Source files are in: $SRC_DIR"
echo ""
echo "Next steps:"
echo "  1. Review the files in dist/"
echo "  2. Test the package with: npm pack"
echo "  3. Publish to npm with: npm publish"

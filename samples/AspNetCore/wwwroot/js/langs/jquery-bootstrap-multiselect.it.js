/*!
 * Bootstrap MultiSelect - Italian (Italiano) Localization v1.1.0
 * 
 * This file provides Italian language support for the Bootstrap MultiSelect plugin.
 * Load this file after jquery-bootstrap-multiselect.js to enable Italian localization.
 * 
 * Usage:
 * 1. Include this file after the main plugin:
 *    <script src="js/jquery-bootstrap-multiselect.js"></script>
 *    <script src="js/langs/jquery-bootstrap-multiselect.it.js"></script>
 * 
 * 2. The locale is automatically set to Italian when this file is loaded.
 *    All multiselect instances will now use Italian by default.
 * 
 * 3. You can override the language per instance if needed:
 *    $('#mySelect').bootstrapMultiSelect({ lang: 'en' });
 * 
 * @author Paolo Gaetano
 * @version 1.0.0
 * @license MIT
 */

(function ($) {
    'use strict';

    // Ensure the plugin namespace exists
    $.fn.bootstrapMultiSelect = $.fn.bootstrapMultiSelect || {};
    $.fn.bootstrapMultiSelect.langs = $.fn.bootstrapMultiSelect.langs || {};

    // Register Italian language
    $.fn.bootstrapMultiSelect.langs['it'] = {
        /**
         * Placeholder text shown when no items are selected
         */
        placeholder: 'Seleziona elementi...',

        /**
         * Placeholder text for the search input field
         */
        searchPlaceholder: 'Cerca...',

        /**
         * Text for the "Select All" button
         */
        selectAllText: 'Seleziona Tutti',

        /**
         * Text for the "Deselect All" button
         */
        deselectAllText: 'Deseleziona Tutti',

        /**
         * Message displayed when search returns no results
         */
        noResultsText: 'Nessun risultato trovato',

        /**
         * Text shown when multiple items (4+) are selected
         * Example: "5 elementi selezionati"
         */
        itemsSelectedText: 'elementi selezionati'
    };

    // Note: This file only registers the Italian translation.
    // To use Italian globally, add this line after loading this file:
    // $.fn.bootstrapMultiSelect.lang = 'it';
    //
    // Or use data-lang="it" on specific elements to use Italian for those instances only.

})(jQuery);

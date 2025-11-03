/*!
 * Bootstrap MultiSelect - German (Deutsch) Localization v1.1.0
 * 
 * This file provides German language support for the Bootstrap MultiSelect plugin.
 * Load this file after jquery-bootstrap-multiselect.js to enable German localization.
 * 
 * Usage:
 * 1. Include this file after the main plugin:
 *    <script src="js/jquery-bootstrap-multiselect.js"></script>
 *    <script src="js/langs/jquery-bootstrap-multiselect.de.js"></script>
 * 
 * 2. Set the global language (affects all instances):
 *    $.fn.bootstrapMultiSelect.lang = 'de';
 * 
 * 3. Or set language per instance:
 *    $('#mySelect').bootstrapMultiSelect({ lang: 'de' });
 * 
 * @author Paolo Gaetano
 * @version 1.1.0
 * @license MIT
 */

(function ($) {
    'use strict';

    // Ensure the plugin namespace exists
    $.fn.bootstrapMultiSelect = $.fn.bootstrapMultiSelect || {};
    $.fn.bootstrapMultiSelect.langs = $.fn.bootstrapMultiSelect.langs || {};

    // Register German language
    $.fn.bootstrapMultiSelect.langs['de'] = {
        placeholder: 'Elemente auswählen...',
        searchPlaceholder: 'Suchen...',
        selectAllText: 'Alle Auswählen',
        deselectAllText: 'Alle Abwählen',
        noResultsText: 'Keine Ergebnisse gefunden',
        itemsSelectedText: 'Elemente ausgewählt'
    };

    // Note: This file only registers the German translation.
    // To use German globally, add this line after loading this file:
    // $.fn.bootstrapMultiSelect.lang = 'de';
    //
    // Or use data-lang="de" on specific elements to use German for those instances only.

})(jQuery);

/*!
 * Bootstrap MultiSelect - French (Français) Localization v1.2.0
 * 
 * This file provides French language support for the Bootstrap MultiSelect plugin.
 * Load this file after jquery-bootstrap-multiselect.js to enable French localization.
 * 
 * Usage:
 * 1. Include this file after the main plugin:
 *    <script src="js/jquery-bootstrap-multiselect.js"></script>
 *    <script src="js/langs/jquery-bootstrap-multiselect.fr.js"></script>
 * 
 * 2. Set the global language (affects all instances):
 *    $.fn.bootstrapMultiSelect.lang = 'fr';
 * 
 * 3. Or set language per instance:
 *    $('#mySelect').bootstrapMultiSelect({ lang: 'fr' });
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

    // Register French language
    $.fn.bootstrapMultiSelect.langs['fr'] = {
        placeholder: 'Sélectionner des éléments...',
        searchPlaceholder: 'Rechercher...',
        selectAllText: 'Tout Sélectionner',
        deselectAllText: 'Tout Désélectionner',
        noResultsText: 'Aucun résultat trouvé',
        itemsSelectedText: 'éléments sélectionnés',
        paginationPrevText: 'Précédent',
        paginationNextText: 'Suivant',
        paginationInfoText: 'Page {current} sur {total}'
    };

    // Note: This file only registers the French translation.
    // To use French globally, add this line after loading this file:
    // $.fn.bootstrapMultiSelect.lang = 'fr';
    //
    // Or use data-lang="fr" on specific elements to use French for those instances only.

})(jQuery);

/*!
 * Bootstrap MultiSelect - Spanish (Español) Localization v1.2.0
 * 
 * This file provides Spanish language support for the Bootstrap MultiSelect plugin.
 * Load this file after jquery-bootstrap-multiselect.js to enable Spanish localization.
 * 
 * Usage:
 * 1. Include this file after the main plugin:
 *    <script src="js/jquery-bootstrap-multiselect.js"></script>
 *    <script src="js/langs/jquery-bootstrap-multiselect.es.js"></script>
 * 
 * 2. Set the global language (affects all instances):
 *    $.fn.bootstrapMultiSelect.lang = 'es';
 * 
 * 3. Or set language per instance:
 *    $('#mySelect').bootstrapMultiSelect({ lang: 'es' });
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

    // Register Spanish language
    $.fn.bootstrapMultiSelect.langs['es'] = {
        placeholder: 'Seleccionar elementos...',
        searchPlaceholder: 'Buscar...',
        selectAllText: 'Seleccionar Todo',
        deselectAllText: 'Deseleccionar Todo',
        noResultsText: 'No se encontraron resultados',
        itemsSelectedText: 'elementos seleccionados',
        paginationPrevText: 'Anterior',
        paginationNextText: 'Siguiente',
        paginationInfoText: 'Página {current} de {total}'
    };

    // Note: This file only registers the Spanish translation.
    // To use Spanish globally, add this line after loading this file:
    // $.fn.bootstrapMultiSelect.lang = 'es';
    //
    // Or use data-lang="es" on specific elements to use Spanish for those instances only.

})(jQuery);

/*!
 * Bootstrap MultiSelect - jQuery Plugin v1.1.0
 * 
 * A powerful multi-select dropdown plugin built with Bootstrap 5
 * Supports declarative configuration via data attributes and programmatic control via JavaScript API
 * 
 * This plugin transforms standard HTML select elements or input fields into feature-rich
 * multi-select dropdowns with search, filtering, select all/deselect all functionality,
 * maximum selection limits, disabled options, optgroup support, and more.
 * 
 * Authors: Paolo Gaetano
 * Copyright (c) 2026 Paolo Gaetano
 * Released under the MIT license
 * 
 * @requires jQuery >= 3.6
 * @requires Bootstrap >= 5.0
 */

(function ($) {
    /**
     * Bootstrap MultiSelect - jQuery Plugin
     * 
     * A powerful multi-select dropdown plugin built with Bootstrap 5
     * Supports declarative configuration via data attributes and programmatic control via JavaScript API
     * 
     * @requires jQuery >= 3.6
     * @requires Bootstrap >= 5.0
     * 
     * @description
     * This plugin transforms standard HTML select elements or input fields into feature-rich
     * multi-select dropdowns with search, filtering, select all/deselect all functionality,
     * maximum selection limits, disabled options, optgroup support, and more.
     * 
     * @example
     * // Basic usage with a select element
     * <select id="mySelect" data-toggle="bootstrap-multiselect">
     *     <option value="1">Option 1</option>
     *     <option value="2">Option 2</option>
     *     <option value="3">Option 3</option>
     * </select>
     * 
     * @example
     * // Declarative configuration via data attributes
     * <select data-toggle="bootstrap-multiselect"
     *         data-placeholder="Select items..."
     *         data-search="true"
     *         data-select-all="true"
     *         data-max-selection="3"
     *         data-theme="primary">
     *     <option value="1">Option 1</option>
     *     <option value="2" selected>Option 2</option>
     *     <option value="3" disabled>Option 3 (Disabled)</option>
     * </select>
     * 
     * @example
     * // Programmatic initialization with JavaScript
     * $('#mySelect').bootstrapMultiSelect({
     *     placeholder: 'Choose options...',
     *     search: true,
     *     selectAll: true,
     *     maxSelection: 5,
     *     theme: 'success',
     *     width: '300px',
     *     data: [
     *         { id: '1', text: 'Option 1' },
     *         { id: '2', text: 'Option 2', selected: true },
     *         { id: '3', text: 'Option 3', disabled: true }
     *     ]
     * });
     * 
     * @example
     * // Using OptGroups
     * <select data-toggle="bootstrap-multiselect">
     *     <optgroup label="Fruits">
     *         <option value="apple">Apple</option>
     *         <option value="banana">Banana</option>
     *     </optgroup>
     *     <optgroup label="Vegetables">
     *         <option value="carrot">Carrot</option>
     *         <option value="broccoli">Broccoli</option>
     *     </optgroup>
     * </select>
     * 
     * @example
     * // JavaScript API - Get selected values
     * var selected = $('#mySelect').bootstrapMultiSelect('getSelectedValues');
     * console.log(selected); // ['1', '2', '3']
     * 
     * @example
     * // JavaScript API - Set selected values
     * $('#mySelect').bootstrapMultiSelect('setSelectedValues', ['1', '3', '5']);
     * 
     * @example
     * // JavaScript API - Refresh the dropdown
     * $('#mySelect').bootstrapMultiSelect('refresh');
     * 
     * @example
     * // JavaScript API - Reset to empty state
     * $('#mySelect').bootstrapMultiSelect('reset');
     * 
     * @example
     * // JavaScript API - Enable/Disable the control
     * $('#mySelect').bootstrapMultiSelect('disable');
     * $('#mySelect').bootstrapMultiSelect('enable');
     * 
     * @example
     * // JavaScript API - Destroy the plugin
     * $('#mySelect').bootstrapMultiSelect('destroy');
     * 
     * @example
     * // Listen to change events
     * $('#mySelect').on('change.bs-multiselect', function(e, selectedValues) {
     *     console.log('Selected values:', selectedValues);
     * });
     * 
     * @example
     * // Advanced configuration with all options
     * $('#mySelect').bootstrapMultiSelect({
     *     placeholder: 'Select items...',
     *     maxSelection: 3,              // Max number of items that can be selected
     *     selectAll: true,              // Show "Select All" button
     *     search: true,                 // Enable search functionality
     *     width: '100%',                // Width of the dropdown
     *     theme: 'primary',             // Bootstrap theme (primary, success, danger, etc.)
     *     closeOnSelect: false,         // Keep dropdown open after selecting an item
     *     buttonClass: 'btn-outline-primary',  // Custom button class
     *     dropdownClass: 'custom-dropdown',    // Custom dropdown class
     *     searchPlaceholder: 'Search...',      // Search input placeholder
     *     selectAllText: 'Select All',         // Text for select all button
     *     deselectAllText: 'Deselect All',     // Text for deselect all button
     *     noResultsText: 'No results found',   // Text when search has no results
     *     maxHeight: '300px',                  // Max height of dropdown
     *     valueField: 'id',                    // Field name for value
     *     textField: 'text'                    // Field name for display text
     * });
     * 
     * @fires change.bs-multiselect - Triggered when selection changes
     * 
     * @see https://getbootstrap.com/docs/5.3/getting-started/introduction/
     * @see https://jquery.com/
     */
    'use strict';

    // Ensure the plugin namespace exists
    $.fn.bootstrapMultiSelect = $.fn.bootstrapMultiSelect || {};

    /**
     * Global localization storage
     * Can be overridden by loading a localization file
     */
    $.fn.bootstrapMultiSelect.langs = $.fn.bootstrapMultiSelect.langs || {
        'en': {
            placeholder: 'Select items...',
            searchPlaceholder: 'Search...',
            selectAllText: 'Select All',
            deselectAllText: 'Deselect All',
            noResultsText: 'No results found',
            itemsSelectedText: 'items selected'
        }
    };

    /**
     * Default language (can be changed globally)
     */
    $.fn.bootstrapMultiSelect.lang = $.fn.bootstrapMultiSelect.lang || 'en';

    /**
     * Default plugin options
     */
    const defaults = {
        placeholder: 'Select items...',
        maxSelection: 0,
        selectAll: true,
        search: true,
        width: '100%',
        theme: 'primary',
        data: [],
        valueField: 'id',
        textField: 'text',
        selectedValues: [],
        closeOnSelect: false,
        enableClickableOptGroups: false,
        buttonClass: 'btn-outline-secondary',
        dropdownClass: '',
        searchPlaceholder: 'Search...',
        selectAllText: 'Select All',
        deselectAllText: 'Deselect All',
        noResultsText: 'No results found',
        maxHeight: '300px',
        itemsSelectedText: 'items selected',
        lang: null // If null, uses global lang
    };

    /**
     * BootstrapMultiSelect class
     */
    class BootstrapMultiSelect {
        /**
         * Constructor
         * 
         * @param {HTMLElement} element - The input/select element
         * @param {Object} options - Plugin options
         */
        constructor(element, options) {
            this.$element = $(element);
            this.options = this._getOptions(options);
            this.id = this._generateId();
            this.isOpen = false;
            this.selectedItems = [];

            this._init();
        }

        /**
         * Get merged options from defaults, data attributes, and passed options
         * 
         * @param {Object} options - User provided options
         * @returns {Object} Merged options
         */
        _getOptions(options) {
            const dataOptions = {
                placeholder: this.$element.data('placeholder'),
                maxSelection: this.$element.data('max-selection'),
                selectAll: this.$element.data('select-all'),
                search: this.$element.data('search'),
                width: this.$element.data('width'),
                theme: this.$element.data('theme'),
                valueField: this.$element.data('value-field'),
                textField: this.$element.data('text-field'),
                closeOnSelect: this.$element.data('close-on-select'),
                buttonClass: this.$element.data('button-class'),
                dropdownClass: this.$element.data('dropdown-class'),
                searchPlaceholder: this.$element.data('search-placeholder'),
                selectAllText: this.$element.data('select-all-text'),
                deselectAllText: this.$element.data('deselect-all-text'),
                noResultsText: this.$element.data('no-results-text'),
                maxHeight: this.$element.data('max-height'),
                itemsSelectedText: this.$element.data('items-selected-text'),
                lang: this.$element.data('lang')
            };

            // Remove undefined values
            Object.keys(dataOptions).forEach(key => {
                if (dataOptions[key] === undefined) {
                    delete dataOptions[key];
                }
            });

            // Merge options: defaults -> data attributes -> passed options
            const mergedOptions = $.extend(true, {}, defaults, dataOptions, options);

            // Apply global localization if lang is specified and no text overrides are provided
            if ($.fn.bootstrapMultiSelect && $.fn.bootstrapMultiSelect.langs) {
                // Use explicit lang from user (data-lang or options.lang), otherwise use global lang
                let lang;
                if (dataOptions.lang !== undefined) {
                    // User specified data-lang attribute
                    lang = dataOptions.lang;
                } else if (options && options.lang !== undefined) {
                    // User specified lang in JavaScript options
                    lang = options.lang;
                } else {
                    // No user specification, use global lang
                    lang = $.fn.bootstrapMultiSelect.lang || 'en';
                }

                const langData = $.fn.bootstrapMultiSelect.langs[lang];

                if (langData) {
                    // Only apply lang values if they weren't explicitly set by user
                    if (!dataOptions.placeholder && !options?.placeholder) {
                        mergedOptions.placeholder = langData.placeholder;
                    }
                    if (!dataOptions.searchPlaceholder && !options?.searchPlaceholder) {
                        mergedOptions.searchPlaceholder = langData.searchPlaceholder;
                    }
                    if (!dataOptions.selectAllText && !options?.selectAllText) {
                        mergedOptions.selectAllText = langData.selectAllText;
                    }
                    if (!dataOptions.deselectAllText && !options?.deselectAllText) {
                        mergedOptions.deselectAllText = langData.deselectAllText;
                    }
                    if (!dataOptions.noResultsText && !options?.noResultsText) {
                        mergedOptions.noResultsText = langData.noResultsText;
                    }
                    if (!dataOptions.itemsSelectedText && !options?.itemsSelectedText) {
                        mergedOptions.itemsSelectedText = langData.itemsSelectedText;
                    }
                }
            }

            return mergedOptions;
        }

        /**
         * Generate unique ID for the component
         * 
         * @returns {string} Unique ID
         */
        _generateId() {
            return 'bs-multiselect-' + Math.random().toString(36).substr(2, 9);
        }

        /**
         * Initialize the plugin
         */
        _init() {
            // Hide original element but keep it in the DOM for validation
            this.$element.css({
                'position': 'absolute',
                'left': '-9999px',
                'width': '1px',
                'height': '1px'
            });

            // Get data from select element or options
            this._loadData();

            // Build the dropdown structure
            this._buildDropdown();

            // Set initial selection BEFORE binding events to avoid triggering change handlers
            this._setInitialSelection();

            // Bind events
            this._bindEvents();
        }

        /**
         * Load data from select element or options
         */
        _loadData() {
            // If data is provided in options, use it
            if (this.options.data && Array.isArray(this.options.data) && this.options.data.length > 0) {
                // Data is already set in options, no need to parse from element
                return;
            }

            // Otherwise, try to parse from select element
            if (this.$element.is('select')) {
                this.options.data = this._parseSelectOptions();
            }
        }

        /**
         * Parse options from select element
         * 
         * @returns {Array} Array of option objects
         */
        _parseSelectOptions() {
            const data = [];
            const self = this;

            this.$element.find('option, optgroup').each(function () {
                const $this = $(this);

                if ($this.is('optgroup')) {
                    const group = {
                        label: $this.attr('label'),
                        children: []
                    };

                    $this.find('option').each(function () {
                        const $option = $(this);
                        group.children.push({
                            [self.options.valueField]: $option.val(),
                            [self.options.textField]: $option.text(),
                            selected: $option.prop('selected'),
                            disabled: $option.prop('disabled')
                        });
                    });

                    data.push(group);
                } else if (!$this.parent().is('optgroup')) {
                    data.push({
                        [self.options.valueField]: $this.val(),
                        [self.options.textField]: $this.text(),
                        selected: $this.prop('selected'),
                        disabled: $this.prop('disabled')
                    });
                }
            });

            return data;
        }

        /**
         * Build the dropdown HTML structure
         */
        _buildDropdown() {
            const buttonClass = this.options.buttonClass || `btn-outline-${this.options.theme}`;

            this.$container = $(`
                <div class="bs-multiselect-container dropdown" style="width: ${this.options.width}">
                    <button class="btn ${buttonClass} dropdown-toggle w-100 text-start d-flex justify-content-between align-items-center" 
                            type="button" 
                            id="${this.id}-button" 
                            data-bs-toggle="dropdown" 
                            aria-expanded="false">
                        <span class="bs-multiselect-placeholder">${this.options.placeholder}</span>
                        <span class="bs-multiselect-badge badge bg-${this.options.theme} ms-2" style="display: none;">0</span>
                    </button>
                    <div class="dropdown-menu w-100 ${this.options.dropdownClass}" 
                         aria-labelledby="${this.id}-button" 
                         style="max-height: ${this.options.maxHeight}; overflow-y: auto;">
                        ${this._buildDropdownContent()}
                    </div>
                </div>
            `);

            this.$element.after(this.$container);

            // Store references
            this.$button = this.$container.find('.dropdown-toggle');
            this.$dropdownMenu = this.$container.find('.dropdown-menu');
            this.$placeholder = this.$container.find('.bs-multiselect-placeholder');
            this.$badge = this.$container.find('.bs-multiselect-badge');
            this.$searchInput = this.$container.find('.bs-multiselect-search');
            this.$selectAllBtn = this.$container.find('.bs-multiselect-select-all');
            this.$deselectAllBtn = this.$container.find('.bs-multiselect-deselect-all');
            this.$optionsList = this.$container.find('.bs-multiselect-options');
            this.$noResults = this.$container.find('.bs-multiselect-no-results');
        }

        /**
         * Build dropdown content HTML
         * 
         * @returns {string} HTML content
         */
        _buildDropdownContent() {
            let html = '<div class="p-2">';

            // Search box
            if (this.options.search) {
                html += `
                    <div class="mb-2">
                        <input type="text" 
                               class="form-control form-control-sm bs-multiselect-search" 
                               placeholder="${this.options.searchPlaceholder}">
                    </div>
                `;
            }

            // Select All / Deselect All buttons
            if (this.options.selectAll) {
                html += `
                    <div class="mb-2 d-flex gap-2">
                        <button type="button" class="btn btn-sm btn-outline-primary bs-multiselect-select-all flex-fill">
                            ${this.options.selectAllText}
                        </button>
                        <button type="button" class="btn btn-sm btn-outline-secondary bs-multiselect-deselect-all flex-fill">
                            ${this.options.deselectAllText}
                        </button>
                    </div>
                `;
            }

            html += '<hr class="my-2">';

            // Options list
            html += '<div class="bs-multiselect-options">';
            html += this._buildOptions();
            html += '</div>';

            // No results message
            html += `
                <div class="bs-multiselect-no-results text-muted text-center py-2" style="display: none;">
                    <small>${this.options.noResultsText}</small>
                </div>
            `;

            html += '</div>';

            return html;
        }

        /**
         * Build options HTML
         * 
         * @returns {string} Options HTML
         */
        _buildOptions() {
            let html = '';

            this.options.data.forEach((item, index) => {
                if (item.label && item.children) {
                    // OptGroup
                    html += this._buildOptGroup(item, index);
                } else {
                    // Regular option
                    html += this._buildOption(item, index);
                }
            });

            return html;
        }

        /**
         * Build option group HTML
         * 
         * @param {Object} group - Group object
         * @param {number} index - Group index
         * @returns {string} OptGroup HTML
         */
        _buildOptGroup(group, index) {
            let html = `
                <div class="bs-multiselect-optgroup" data-group-index="${index}">
                    <div class="fw-bold text-muted small px-2 py-1">${group.label}</div>
                    <div class="ps-3">
            `;

            group.children.forEach((child, childIndex) => {
                html += this._buildOption(child, `${index}-${childIndex}`, true);
            });

            html += '</div></div>';

            return html;
        }

        /**
         * Build single option HTML
         * 
         * @param {Object} option - Option object
         * @param {string|number} index - Option index
         * @param {boolean} isChild - Is child of optgroup
         * @returns {string} Option HTML
         */
        _buildOption(option, index, isChild = false) {
            const value = option[this.options.valueField];
            const text = option[this.options.textField];
            const disabled = option.disabled ? 'disabled' : '';
            const disabledData = option.disabled ? 'data-original-disabled="true"' : '';
            // Don't set checked attribute here - let _setInitialSelection handle it
            // to avoid double-triggering events

            return `
                <div class="form-check bs-multiselect-option" data-value="${value}" data-index="${index}">
                    <input class="form-check-input" 
                           type="checkbox" 
                           value="${value}" 
                           id="${this.id}-option-${index}" 
                           ${disabled}
                           ${disabledData}>
                    <label class="form-check-label w-100" for="${this.id}-option-${index}">
                        ${text}
                    </label>
                </div>
            `;
        }

        /**
         * Bind event handlers
         */
        _bindEvents() {
            const self = this;

            // Prevent dropdown from closing on inside click
            this.$dropdownMenu.on('click', function (e) {
                if (!self.options.closeOnSelect) {
                    e.stopPropagation();
                }
            });

            // Checkbox change event
            this.$dropdownMenu.on('change', '.form-check-input', function (e) {
                e.stopPropagation();
                self._onOptionChange($(this));
            });

            // Select All button
            this.$selectAllBtn.on('click', function (e) {
                e.preventDefault();
                e.stopPropagation();
                self._selectAll();
            });

            // Deselect All button
            this.$deselectAllBtn.on('click', function (e) {
                e.preventDefault();
                e.stopPropagation();
                self._deselectAll();
            });

            // Search input
            if (this.options.search) {
                this.$searchInput.on('input', function () {
                    self._filterOptions($(this).val());
                });
            }

            // Dropdown shown/hidden events
            this.$container.on('shown.bs.dropdown', function () {
                self.isOpen = true;
                if (self.options.search) {
                    self.$searchInput.focus();
                }
            });

            this.$container.on('hidden.bs.dropdown', function () {
                self.isOpen = false;
                if (self.options.search) {
                    self.$searchInput.val('');
                    self._filterOptions('');
                }
            });

            // Intercept parent form reset event
            const $form = this.$element.closest('form');
            if ($form.length > 0) {
                $form.on('reset.bs-multiselect', function (e) {
                    // Use setTimeout to wait for the browser's default reset behavior to complete
                    setTimeout(function () {
                        self.reset();
                    }, 0);
                });

                // Intercept form submit to trigger validation before submission
                $form.on('submit.bs-multiselect', function (e) {
                    // Validate this element if jQuery Validation is present
                    if ($.validator && $form.data('validator')) {
                        // Use setTimeout to let validation run first
                        setTimeout(function () {
                            const validator = $form.data('validator');
                            const elementName = self.$element.attr('name');

                            // Only update validation state if this element has validation rules
                            if (validator.settings.rules && validator.settings.rules[elementName]) {
                                const hasError = validator.invalid && validator.invalid[elementName];
                                self._updateValidationState(!hasError);
                            }
                        }, 0);
                    }
                });
            }

            // Listen to jQuery Validation events if present
            if ($.validator) {
                this.$element.on('invalid-form.validate', function () {
                    self._updateValidationState(false);
                });

                // Update validation state when element becomes valid
                this.$element.on('change', function () {
                    setTimeout(function () {
                        const $form = self.$element.closest('form');
                        if ($form.length && $form.data('validator')) {
                            const validator = $form.data('validator');
                            const elementName = self.$element.attr('name');

                            // Only update validation state if this element has validation rules
                            if (validator.settings.rules && validator.settings.rules[elementName]) {
                                const hasError = validator.invalid && validator.invalid[elementName];
                                self._updateValidationState(!hasError);
                            }
                        }
                    }, 100);
                });
            }
        }

        /**
         * Handle option checkbox change
         * 
         * @param {jQuery} $checkbox - Checkbox element
         */
        _onOptionChange($checkbox) {
            const value = $checkbox.val();
            const isChecked = $checkbox.prop('checked');

            if (isChecked) {
                // Check max selection limit
                if (this.options.maxSelection > 0 && this.selectedItems.length >= this.options.maxSelection) {
                    $checkbox.prop('checked', false);
                    this._showMaxSelectionWarning();
                    return;
                }

                this.selectedItems.push(value);
            } else {
                const index = this.selectedItems.indexOf(value);
                if (index > -1) {
                    this.selectedItems.splice(index, 1);
                }
            }

            this._updateDisplay();
            this._updateValue();
            this._triggerChange();
            this._updateMaxSelectionState();
        }

        /**
         * Select all options
         */
        _selectAll() {
            const self = this;
            // Get only checkboxes that are not originally disabled
            const $visibleCheckboxes = this.$optionsList.find('.bs-multiselect-option:visible .form-check-input').filter(function () {
                return !$(this).data('original-disabled');
            });

            if (this.options.maxSelection > 0) {
                const limit = this.options.maxSelection;
                const currentCount = this.selectedItems.length;
                const availableSlots = limit - currentCount;

                if (availableSlots <= 0) {
                    this._showMaxSelectionWarning();
                    return;
                }

                // Select only unchecked items up to the available slots
                let slotsUsed = 0;
                $visibleCheckboxes.each(function () {
                    const $checkbox = $(this);
                    if (!$checkbox.prop('checked') && slotsUsed < availableSlots) {
                        $checkbox.prop('checked', true);
                        self.selectedItems.push($checkbox.val());
                        slotsUsed++;
                    }
                });

                if (slotsUsed < $visibleCheckboxes.filter(':not(:checked)').length) {
                    this._showMaxSelectionWarning();
                }
            } else {
                $visibleCheckboxes.each(function () {
                    const $checkbox = $(this);
                    if (!$checkbox.prop('checked')) {
                        $checkbox.prop('checked', true);
                        self.selectedItems.push($checkbox.val());
                    }
                });
            }

            // Remove duplicates
            this.selectedItems = [...new Set(this.selectedItems)];

            this._updateDisplay();
            this._updateValue();
            this._triggerChange();
            this._updateMaxSelectionState();
        }

        /**
         * Deselect all options
         */
        _deselectAll() {
            this.$optionsList.find('.form-check-input:checked').prop('checked', false);
            this.selectedItems = [];

            this._updateDisplay();
            this._updateValue();
            this._triggerChange();
            this._updateMaxSelectionState();
        }

        /**
         * Filter options based on search query
         * 
         * @param {string} query - Search query
         */
        _filterOptions(query) {
            const searchTerm = query.toLowerCase().trim();

            if (!searchTerm) {
                this.$optionsList.find('.bs-multiselect-option, .bs-multiselect-optgroup').show();
                this.$noResults.hide();
                return;
            }

            let visibleCount = 0;

            this.$optionsList.find('.bs-multiselect-option').each(function () {
                const $option = $(this);
                const text = $option.find('.form-check-label').text().toLowerCase();

                if (text.includes(searchTerm)) {
                    $option.show();
                    visibleCount++;
                } else {
                    $option.hide();
                }
            });

            // Handle optgroups
            this.$optionsList.find('.bs-multiselect-optgroup').each(function () {
                const $group = $(this);
                const visibleChildren = $group.find('.bs-multiselect-option:visible').length;

                if (visibleChildren > 0) {
                    $group.show();
                } else {
                    $group.hide();
                }
            });

            // Show/hide no results message
            if (visibleCount === 0) {
                this.$noResults.show();
            } else {
                this.$noResults.hide();
            }
        }

        /**
         * Update button display with selected items
         */
        _updateDisplay() {
            const count = this.selectedItems.length;

            if (count === 0) {
                this.$placeholder.text(this.options.placeholder);
                this.$badge.hide();
                this.$badge.text('0');
            } else {
                // Get selected items text
                const selectedTexts = [];
                const self = this;

                this.selectedItems.forEach(value => {
                    const $checkbox = this.$optionsList.find(`.form-check-input[value="${value}"]`);
                    const text = $checkbox.next('.form-check-label').text();
                    selectedTexts.push(text);
                });

                // Display selected items (max 3 items in text)
                if (count <= 3) {
                    this.$placeholder.text(selectedTexts.join(', '));
                } else {
                    this.$placeholder.text(`${count} ${this.options.itemsSelectedText}`);
                }

                this.$badge.text(count).show();
            }
        }

        /**
         * Update the original input value
         */
        _updateValue() {
            // Update original element
            if (this.$element.is('select')) {
                // First, deselect all options
                this.$element.find('option').prop('selected', false);

                // Then select only the items in selectedItems array
                if (this.selectedItems.length > 0) {
                    this.selectedItems.forEach(value => {
                        this.$element.find(`option[value="${value}"]`).prop('selected', true);
                    });
                }

                // Important: Set the select's value to ensure proper form submission
                // For multi-select, val() should be an array
                this.$element.val(this.selectedItems.length > 0 ? this.selectedItems : null);
            } else {
                // For input elements, store as JSON (empty array if no items)
                this.$element.val(this.selectedItems.length > 0 ? JSON.stringify(this.selectedItems) : '');
            }

            // Trigger native change event for validation frameworks (like jQuery Validation)
            this.$element.trigger('change');
        }

        /**
         * Trigger change event
         */
        _triggerChange() {
            this.$element.trigger('change.bs-multiselect', [{
                selectedValues: this.selectedItems
            }]);

            // Trigger validation if jQuery Validation is present
            const $form = this.$element.closest('form');
            if ($.validator && $form.length > 0 && $form.data('validator')) {
                const self = this;
                const elementName = self.$element.attr('name');
                const validator = $form.data('validator');

                // Only validate if this element has validation rules
                if (validator.settings.rules && validator.settings.rules[elementName]) {
                    // Force validation on this element
                    const isValid = self.$element.valid();

                    // Update visual state after validation
                    setTimeout(function () {
                        // Check if there are errors after validation
                        const hasError = validator.invalid && validator.invalid[elementName];
                        self._updateValidationState(!hasError);
                    }, 50);
                }
            }
        }

        /**
         * Update validation state visual feedback
         */
        _updateValidationState(isValid) {
            if (isValid) {
                // Remove error styling
                this.$button.removeClass('is-invalid border-danger');
                this.$button.addClass('is-valid');
            } else {
                // Add error styling
                this.$button.removeClass('is-valid');
                this.$button.addClass('is-invalid border-danger');
            }
        }

        /**
         * Set initial selection from element
         */
        _setInitialSelection() {
            const self = this;

            // Priority 1: If element is a select, read directly from DOM (most reliable for TagHelper/HtmlHelper)
            if (this.$element.is('select')) {
                // Only select options that have the 'selected' ATTRIBUTE in HTML (not the property)
                // This is important because browsers may set the first option's selected property to true by default
                this.$element.find('option[selected]').each(function () {
                    const value = $(this).val();
                    if (value && !self.selectedItems.includes(value)) {
                        self.selectedItems.push(value);
                    }
                });
            }
            // Priority 2: Check for selectedValues in options (programmatic initialization)
            else if (this.options.selectedValues && Array.isArray(this.options.selectedValues) && this.options.selectedValues.length > 0) {
                this.selectedItems = [...this.options.selectedValues];
            }
            // Priority 3: Check for pre-selected items in data array
            else if (this.options.data && Array.isArray(this.options.data)) {
                this.options.data.forEach(item => {
                    if (item.children) {
                        // Handle optgroup
                        item.children.forEach(child => {
                            if (child.selected) {
                                const value = child[this.options.valueField];
                                if (value && !self.selectedItems.includes(value)) {
                                    self.selectedItems.push(value);
                                }
                            }
                        });
                    } else if (item.selected) {
                        // Handle regular option
                        const value = item[this.options.valueField];
                        if (value && !this.selectedItems.includes(value)) {
                            self.selectedItems.push(value);
                        }
                    }
                });
            }
            // Priority 4: Read from input element value (JSON format)
            else if (this.$element.val()) {
                try {
                    const values = JSON.parse(this.$element.val());
                    if (Array.isArray(values)) {
                        this.selectedItems = values;
                    }
                } catch (e) {
                    // Invalid JSON, ignore
                }
            }

            // Save initial values for reset functionality
            this.initialSelectedItems = [...this.selectedItems];

            // Update checkboxes
            this.selectedItems.forEach(value => {
                this.$optionsList.find(`.form-check-input[value="${value}"]`).prop('checked', true);
            });

            this._updateDisplay();
            this._updateValue();
            this._updateMaxSelectionState();
        }

        /**
         * Update the state of checkboxes based on max selection limit
         */
        _updateMaxSelectionState() {
            if (this.options.maxSelection > 0) {
                const limitReached = this.selectedItems.length >= this.options.maxSelection;

                // Disable unchecked options if limit is reached
                this.$optionsList.find('.form-check-input').each(function () {
                    const $checkbox = $(this);
                    const isChecked = $checkbox.prop('checked');
                    const isDisabled = $checkbox.data('original-disabled') === true;

                    if (!isDisabled) {
                        if (limitReached && !isChecked) {
                            $checkbox.prop('disabled', true);
                            $checkbox.closest('.bs-multiselect-option').addClass('disabled');
                        } else {
                            $checkbox.prop('disabled', false);
                            $checkbox.closest('.bs-multiselect-option').removeClass('disabled');
                        }
                    }
                });

                // Disable "Select All" button if limit is reached
                const $selectAllBtn = this.$dropdownMenu.find('.bs-multiselect-select-all');
                if (limitReached) {
                    $selectAllBtn.prop('disabled', true).addClass('disabled');
                } else {
                    $selectAllBtn.prop('disabled', false).removeClass('disabled');
                }
            }
        }

        /**
         * Show max selection warning
         */
        _showMaxSelectionWarning() {
            // You can customize this to show a toast, alert, or tooltip
            console.warn(`Maximum selection limit reached (${this.options.maxSelection})`);
        }

        /**
         * Get selected values
         * 
         * @returns {Array} Array of selected values
         */
        getSelectedValues() {
            return [...this.selectedItems];
        }

        /**
         * Set selected values
         * 
         * @param {Array} values - Array of values to select
         */
        setSelectedValues(values) {
            if (!Array.isArray(values)) {
                return;
            }

            // Clear current selection
            this._deselectAll();

            // Set new selection
            const self = this;
            values.forEach(value => {
                const $checkbox = this.$optionsList.find(`.form-check-input[value="${value}"]`);
                if ($checkbox.length && !$checkbox.prop('disabled')) {
                    $checkbox.prop('checked', true);
                    self.selectedItems.push(value);
                }
            });

            this._updateDisplay();
            this._updateValue();
            this._triggerChange();
        }

        /**
         * Refresh the dropdown (reload data and rebuild)
         */
        refresh() {
            const currentSelection = [...this.selectedItems];
            this.$container.remove();
            this._init();
            this.setSelectedValues(currentSelection);
        }

        /**
         * Destroy the plugin
         */
        destroy() {
            // Remove form event handlers
            const $form = this.$element.closest('form');
            if ($form.length > 0) {
                $form.off('reset.bs-multiselect');
                $form.off('submit.bs-multiselect');
            }

            // Remove jQuery Validation event listeners
            if ($.validator) {
                this.$element.off('invalid-form.validate');
            }

            this.$container.remove();

            // Restore original element visibility
            this.$element.css({
                'position': '',
                'left': '',
                'width': '',
                'height': ''
            }).show();

            this.$element.removeData('bootstrapMultiSelect');
            this.$element.removeData('bs-multiselect');
        }

        /**
         * Enable the multiselect
         */
        enable() {
            this.$button.prop('disabled', false);
        }

        /**
         * Disable the multiselect
         */
        disable() {
            this.$button.prop('disabled', true);
        }

        /**
         * Reset the multiselect to initial state (original selected values from HTML)
         * This restores the selections that were present when the plugin was initialized
         */
        reset() {
            // Deselect all checkboxes first
            this.$optionsList.find('.form-check-input:checked').prop('checked', false);

            // Restore to initial selected items (saved during initialization)
            this.selectedItems = this.initialSelectedItems ? [...this.initialSelectedItems] : [];

            // Update checkboxes for initial selections
            this.selectedItems.forEach(value => {
                this.$optionsList.find(`.form-check-input[value="${value}"]`).prop('checked', true);
            });

            // Update the original select element to match initial state
            if (this.$element.is('select')) {
                this.$element.find('option').prop('selected', false);
                this.selectedItems.forEach(value => {
                    this.$element.find(`option[value="${value}"]`).prop('selected', true);
                });
            }

            // Update display (placeholder and badge)
            this._updateDisplay();

            // Update the hidden select value
            this._updateValue();

            // Update max selection state
            this._updateMaxSelectionState();

            // Trigger change event
            this._triggerChange();
        }
    }

    /**
     * jQuery plugin definition
     * 
     * @param {Object|string} options - Options object or method name
     * @returns {jQuery|*} jQuery object for chaining or method result
     */
    $.fn.bootstrapMultiSelect = function (options) {
        const args = Array.prototype.slice.call(arguments, 1);
        let result;

        this.each(function () {
            const $element = $(this);
            let instance = $element.data('bootstrapMultiSelect');

            if (!instance) {
                instance = new BootstrapMultiSelect(this, typeof options === 'object' ? options : {});
                $element.data('bootstrapMultiSelect', instance);
                // Also save with alternative key for easier access
                $element.data('bs-multiselect', instance);
            } else if (typeof options === 'object') {
                // If instance exists and options is an object with data, update the instance
                if (options.data && Array.isArray(options.data)) {
                    instance.options.data = options.data;
                    instance.refresh();
                }
            }

            if (typeof options === 'string' && typeof instance[options] === 'function') {
                const methodResult = instance[options].apply(instance, args);
                // For getter methods, store the result to return
                if (methodResult !== undefined) {
                    result = methodResult;
                }
            }
        });

        // Return the method result if available, otherwise return jQuery object for chaining
        return result !== undefined ? result : this;
    };

    // Auto-initialize elements with data-toggle="bootstrap-multiselect"
    $(document).ready(function () {
        $('[data-toggle="bootstrap-multiselect"]').bootstrapMultiSelect();
    });

})(jQuery);


const INVALID_FORMAT_MSG = 'Formato de file inválido.';
const FILE_NOT_INSERTED_MSG = 'Não foi possível inserir o file.';
const CANNOT_GET_FILE_MSG = 'Não foi possível obter os arquivos.';

/**
 * @param {input.files} file
 * @return {boolean}
 */
const validateDefaultValues = file => /\.(jpe?g|png|pdf|txt)$/i.test(file.name);

/**
 * @param {input.files} file
 * @return {boolean}
 */
const validateImageFormat = file => /\.(jpe?g|png)$/i.test(file.name);

/**
 * @param {input.files} file
 * @param {string} specifiedFormat
 * @return {boolean}
 */
const validFormats = (file, specifiedFormat) => {

    const validateFormat = {
        '': validateDefaultValues(file),
        'images': validateImageFormat(file)
    };

    return validateFormat[specifiedFormat];
}

/**
 * @param {input['type=file']} input
 * @return {boolean} 
 */
const isCameraInput = input => { return input.hasAttribute("capture"); }

/**
 * @param {input['type=file']} input
 * @param {string} specificFormat -> '' vazio [default] para formatos diversos, 'images' para fotos.
 * @param {string} filledList
 */
async function attachFiles(input, specificFormat, filledList) {

    var arquivos = input.files;

    if (arquivos) {
        arquivos[0].captured = isCameraInput(input);

        for (const file of arquivos) {
            await readFileAsync(file, specificFormat, filledList);
        }
    }
}

/**
 * @param {input.files} file
 * @param {string} specificFormat 
 * @param {string} filledList
 * @return {string} lista de file preenchida [optional] -> show_attached_file.js
 */
function readFileAsync(file, specificFormat, filledList) {

    if (validFormats(file, specificFormat)) {

        return new Promise((resolve, reject) => {
            let reader = new FileReader();

            reader.onload = () => {
                var attachedFile = {
                    'name': file.name,
                    'base64': reader.result,
                    'is_photo': file.captured
                };

                resolve(fillList(attachedFile, filledList));
            };

            reader.onerror = reject;
            reader.readAsDataURL(file);
        });
    } else {
        alert(INVALID_FORMAT_MSG);
        return;
    }
}
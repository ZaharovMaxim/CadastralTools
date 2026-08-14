Imports System.Reflection.Metadata
Imports System.Transactions
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports System.Xaml
Imports NetTopologySuite
Imports NetTopologySuite.Geometries
Imports CadastralTools.StructureElement
Imports System.Text
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class ImportKPT
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '=============================================================================================
    'отрисовка и нумерация полигона на основе кадастрового плана территории (xml-файл) (Росреестр)
    Public Shared Sub RosreestrImportKPT(ByVal tempDirectory As String, Optional nameKvartal As String = "")
        If Directory.Exists(tempDirectory) = False Then
            MsgBox("Не верно задана папка для записи.")
            Exit Sub
        End If
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        '============================================================================================
        'начальные данные для считывания файла xml
        '============================================================================================
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        Dim ObjectCollections As String(,) = Nothing
        Dim CountObjectCollection As Integer = 0
        Dim boolKvartal As Boolean = False 'обрабатывается квартал
        Dim boolspatial_data As Boolean = False
        Dim boolBuild As Boolean = False 'обрабатывается здание
        Dim boolParcel As Boolean = False 'обрабатывается участок
        Dim boolPart As Boolean = False 'обрабатываеся часть участка, здания, сооружения
        Dim boolCounter As Boolean = False 'обрабатывается контур участка
        Dim boolconstruction As Boolean = False 'обрабатывается сооружение
        Dim boolunderconstruction As Boolean = False 'обрабатывается объект незавершенного строительства
        Dim boolboundary As Boolean = False 'обрабатывается граница
        Dim boolcityboundary As Boolean = False 'обрабатывается граница города
        Dim boolzone As Boolean = False 'обрабатывается зона
        Dim boolcoastline As Boolean = False 'береговая полоса
        Dim boolNastr As Boolean = False 'флаг Говорит о том что нужно ли проверять настройки (слой, цвет и т.п.)
        '============================================================================================
        Dim boolNumberSubParcel As Boolean = False
        Dim boolSpatialElements As Boolean = False
        Dim boolCode As Boolean = False
        Dim boolType As Boolean = False
        Dim boolval As Boolean = False
        Dim boolcomdata As Boolean = False
        Dim boolunit As Boolean = False
        'начальное значение номера точки
        Dim Numb As Integer = 1 'номер
        Dim listCoord As Dictionary(Of Integer, List(Of String(,))) = New Dictionary(Of Integer, List(Of String(,)))
        Dim listNetCoordinates As Dictionary(Of Integer, List(Of Coordinates)) = New Dictionary(Of Integer, List(Of Coordinates))
        Dim netCoordinates As Coordinates(,) = {}
        Dim NXYZ As String(,) = {}
        Dim boolX As Boolean = False
        Dim X As String = ""
        Dim boolY As Boolean = False
        Dim Y As String = ""
        Dim boolOrgNumb As Boolean = False
        Dim OrgNumb As String = "" 'номер
        Dim boolnum_geopoint As Boolean = False
        Dim num_geopoint As String = ""
        Dim boolGeopoint_opred As Boolean = False
        Dim Geopoint_opred As String = ""
        Dim boolDelta As Boolean = False
        Dim Delta As String = "0" 'погрешность
        Dim boolgeopoint_zacrep As Boolean = False
        Dim geopoint_zacrep As String = "-" 'закрепление
        Dim boolR As Boolean = False
        Dim r As String = "" 'радиус окружности
        Dim boolGeopointValue As Boolean = False
        Dim GeopointValue As String = ""
        Dim ArrayCounterParcel As String(,) = Nothing
        Dim CountArrayCounterParcel As Integer = 0
        Dim countObject As Integer = 1
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        'тип объекта
        '0-кадастровый квартал
        Dim boolarea_quarter As Boolean = False
        Dim Area_quarter As String = ""
        Dim CadastralBlock As String = "-"
        Dim boolKvartalNumber As Boolean = False
        '1. Общие данные для участков, ОКС и сооружений
        Dim boolCadNumber As Boolean = False 'кадастровый номер объекта
        Dim Cad_Number As String = "" 'полный кадастровый номер объекта
        Dim Cad_Number_Note As String = "" 'для единого землепользования
        Dim Cad_Number_Short As String = "" 'краткий кадастровый номер
        Dim CodTypeObject As String = "" 'код объекта (Земельный участок, сооружение, и т.п.)
        Dim ValTypeObject As String = "" 'значение объекта
        Dim boolDateReg As Boolean = False
        Dim dateReg As String = ""
        'общие для участков и зданий (участки-разрешенное использование, знания - тип здания (жилое, нежилое)
        Dim boolpermitted_use As Boolean = False 'разрешенное использование
        '1. Земельные участки
        Dim StateSubParcel As String = "" 'тип подучастка 01-ранее учтенный 06-учтенный ....
        Dim NumParcel As String = "" 'краткий кадастровый номер
        Dim boolNumberContour As Boolean = False
        Dim NumberContour As Integer = 0 'номер контура
        Dim NumberSubParcel As Integer = 0 'номер части
        Dim areaPart As String = "" 'площадь части участка
        Dim boolcommon_land_cad_number As Boolean = False
        Dim common_land_cad_number As String = ""
        'тип участка
        Dim boolSubTypeParcel As Boolean = False
        Dim SubTypeParcel As String = "" 'тип подучастка землепользование, многоконтурный участок и т.п
        'вид участка
        Dim StateParcel As String = "06" '06-учтенный
        Dim boolStateParcel As Boolean = False
        'категория земель
        Dim boolCategory As Boolean = False
        Dim Category As String = ""
        Dim CodCategory As String = ""
        'разрешенное использование 
        Dim boolRazrIsp As Boolean = False
        Dim byRazrIspByDoc As Boolean = False
        Dim RazrIsp As String = ""
        Dim RazrIspByDoc As String = ""
        'объекты недвижимого имущества на земельном участке
        Dim boolIncluded_object As Boolean = False
        Dim listIncludedObject As List(Of String) = New List(Of String)
        'адрес
        '===============================================================
        Dim boolAdresParcel As Boolean = False
        Dim AddresParcel As String = ""
        Dim boolokato As Boolean = False
        Dim okato As String = ""
        Dim boolkladr As Boolean = False
        Dim kladr As String = ""
        Dim boolpostcode As Boolean = False
        Dim postcode As String = ""
        Dim boolregion As Boolean = False
        Dim region As String = ""
        Dim boolDistrict As Boolean = False
        Dim booltypeDistrict As Boolean = False
        Dim typeDistrict As String = ""
        Dim boolnameDistrict As Boolean = False
        Dim nameDistrict As String = ""
        Dim boolLocality As Boolean = False
        Dim booltypeLocality As Boolean = False
        Dim typeLocality As String = ""
        Dim boolnameLocality As Boolean = False
        Dim nameLocalyty As String = ""
        Dim boolStreet As Boolean = False
        Dim booltypeStreet As Boolean = False
        Dim type_street As String = ""
        Dim boolnameStreet As Boolean = False
        Dim name_street As String = ""
        Dim boolLevel1 As Boolean = False
        Dim booltypeLevel1 As Boolean = False
        Dim typeLevel1 As String = ""
        Dim boolnameLevel1 As Boolean = False
        Dim nameLevel1 As String = ""
        Dim boolLevel2 As Boolean = False
        Dim booltypeLevel2 As Boolean = False
        Dim typeLevel2 As String = ""
        Dim boolnameLevel2 As Boolean = False
        Dim nameLevel2 As String = ""
        Dim boolLevel3 As Boolean = False
        Dim booltypeLevel3 As Boolean = False
        Dim typeLevel3 As String = ""
        Dim boolnameLevel3 As Boolean = False
        Dim nameLevel3 As String = ""
        Dim readable_address As String = ""
        Dim boolreadable_address As Boolean = False
        '====================================================================
        'здания
        Dim boolpurpose As Boolean = False 'тип здания жилое нежилое
        Dim purpose_build As String = ""
        Dim boolposition_description As Boolean = False 'описание местоположения
        Dim pos_description_build As String = ""
        Dim codeBuild As String = "" 'назначение код здания
        Dim permitted_use As String = ""
        Dim boolname As Boolean = False
        Dim Assignatuin As String = ""
        Dim MaterialWall As String = ""
        Dim CountFloat As String = ""
        '============================================================================
        'сооружения
        Dim purpose_construction As String = ""
        Dim boolparams As Boolean = False 'параметры сооружения
        Dim boolbase_parameter As Boolean = False
        Dim booldepth As Boolean = False 'глубина залегания
        Dim baseParameters As String = ""
        Dim depth As String = ""
        Dim boolextension As Boolean = False 'длина
        Dim extension As String = ""
        Dim boolvolume As Boolean = False
        Dim volume As String = ""
        Dim boolbuilt_up_area As Boolean = False
        Dim boolareaConstr As Boolean = False
        '============================================================================
        'границы и зоны
        Dim booltype_boundary As Boolean = False
        Dim type_boundary As String = ""
        Dim boolregistration_date As Boolean = False
        Dim registr_data As String = ""
        Dim boolRegNumbZone As Boolean = False 'номер территориальной зоны
        Dim RegNumbZone As String = "" 'номер зоны
        Dim boolType_zone As Boolean = False
        Dim cod_boundary As String = ""
        Dim type_zona As String = ""
        Dim code_zona As String = ""
        Dim boolNumberZona As Boolean = False
        Dim boolIndexZona As Boolean = False
        Dim NumberZona As String = ""
        Dim IndexZona As String = ""
        Dim boolNameZona As Boolean = False
        Dim name_by_doc As String = ""
        Dim boolDeskZona As Boolean = False
        Dim deskZona As String = ""
        '====================================================================================
        'береговые линии
        Dim boolwater_object_type As Boolean = False
        Dim boolwater_object_name As Boolean = False
        Dim water_object_name As String = ""
        Dim codwater_object_type As String = ""
        Dim water_object_type As String = ""
        '====================================================================================
        'собственник
        Dim boolRightType As Boolean = False
        Dim RightType As String = ""
        Dim boolOwner As Boolean = False
        Dim boolOwnerName As Boolean = False
        Dim ownerName As String = ""
        Dim boolresident As Boolean = False
        Dim encumbranceName As List(Of String) = New List(Of String)
        Dim boolrecord_info As Boolean = False
        Dim boolRightName As Boolean = False
        Dim boolRight_holder As Boolean = False
        Dim boolRightRecords As Boolean = False
        Dim boolRestrictRecords As Boolean = False
        '================================================================================
        'вид права
        Dim typeRight As String = ""
        '===============================================================================
        'реквизиты выписки
        Dim booldate_formation As Boolean = False
        Dim dataVP As String = "-"
        Dim boolregistration_number As Boolean = False
        Dim NumberVP As String = ""
        Dim boolgroup_top_requisites As Boolean = False
        '========================================================
        'площадь участка общая
        Dim boolGlobalArea As Boolean = False
        Dim GlobalArea As String = ""
        Dim deltaArea As String = ""
        Dim booldeltaArea As Boolean = False
        'кадастровая стоимость
        Dim boolCostParcel As Boolean = False
        Dim CostParcel As String = ""
        'Счетчик вершин контура (для массива координат)
        Dim countcoord As Integer = -1
        Dim TypeLineSubParcel As String = ""
        Dim LocalID As Integer = 0
        Dim GlobalID As Integer = 0
        Dim rng As Random = New Random()
        '========================================================================================================
        'запись json
        Dim filePath As String = ""
        Dim userRight As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        '========================================================================================================
        'массив с кадастровыми номерами всех кадастровых объектов
        Dim ArrayOldCadastrNumbers As String() = Nothing
        Dim CountArrayOldCadastrNumbers As Integer = 0
        Dim ArrayOldCadastrRegNumbers As String() = Nothing
        Dim CountArrayOldRegNumbers As Integer = 0
        Dim ArrayOldCadastrKVNumbers As String() = Nothing
        Dim CountArrayOldKVNumbers As Integer = 0
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        'тело программы
        Dim LineErrNumber As Integer = 0
        '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        'выбор файла
        Dim selectedFile As String = ""
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Title = "Выберите XML файл"
            openFileDialog.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*"
            openFileDialog.FilterIndex = 1
            openFileDialog.InitialDirectory = "d:\Примеры NET\ДПТ_Nanocad\"
            openFileDialog.Multiselect = False ' Разрешить выбор только одного файла
            ' Показываем диалог и проверяем результат
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ' Получаем выбранный файл
                selectedFile = openFileDialog.FileName
            End If
        End Using

        If File.Exists(selectedFile) = False Then Exit Sub
        Try
            Dim reader As XmlTextReader = New XmlTextReader(selectedFile)
            Dim countFile As Integer = 0
            While reader.Read()
                Dim NameBlock As String = reader.Name 'читаем ветку
                LineErrNumber += 1
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        'блок общих данных
                        '=====================================================================
                        If NameBlock Like "common_data" Then
                            boolcomdata = True
                        ElseIf NameBlock Like "type" Then
                            boolType = True
                        ElseIf NameBlock Like "code" Then
                            boolCode = True
                        ElseIf NameBlock Like "value" Then
                            boolval = True
                        ElseIf NameBlock Like "unit" Then
                            boolunit = True
                        ElseIf NameBlock Like "name" Then
                            boolname = True
                        ElseIf NameBlock Like "registration_date" Then
                            boolDateReg = True
                        ElseIf NameBlock Like "State" Then
                            boolStateParcel = True
                        ElseIf NameBlock Like "included_object" Then
                            boolIncluded_object = True
                            '============================================================================
                            'кадастровый квартал
                        ElseIf NameBlock Like "area_quarter" Then
                            boolarea_quarter = True 'площадь квартала
                        ElseIf NameBlock Like "cadastral_number" Then
                            boolKvartalNumber = True 'кадастровый номер квартала (КПТ)
                        ElseIf NameBlock Like "quarter_cad_number" Then
                            boolKvartalNumber = True 'кадастровый номер квартала (выписка)
                            '============================================================================
                            'часть участка и контур участка
                        ElseIf NameBlock Like "object_parts" Then
                            boolNastr = False 'сбрасываем настройки
                        ElseIf NameBlock Like "object_part" Then
                            boolPart = True 'часть кадастрового участка
                        ElseIf NameBlock Like "contours" Then
                            'CountCounter = 0
                        ElseIf NameBlock Like "contour" Then
                            'контур объекта
                            boolCounter = True
                            NumberContour = 0
                            '=========================================================
                            'адрес
                        ElseIf NameBlock Like "address" Then
                            boolAdresParcel = True
                        ElseIf NameBlock Like "okato" Then
                            boolokato = True
                        ElseIf NameBlock Like "kladr" Then
                            boolkladr = True
                        ElseIf NameBlock Like "postal_code" Then
                            boolpostcode = True
                        ElseIf NameBlock Like "region" Then
                            boolregion = True
                        ElseIf NameBlock Like "type_district" Then
                            booltypeDistrict = True
                        ElseIf NameBlock Like "name_district" Then
                            boolnameDistrict = True
                        ElseIf NameBlock Like "type_locality" Then
                            booltypeLocality = True
                        ElseIf NameBlock Like "name_locality" Then
                            boolnameLocality = True
                        ElseIf NameBlock Like "type_street" Then
                            booltypeStreet = True
                        ElseIf NameBlock Like "name_street" Then
                            boolnameStreet = True
                        ElseIf NameBlock Like "type_level1" Then
                            booltypeLevel1 = True
                        ElseIf NameBlock Like "name_level1" Then
                            boolnameLevel1 = True
                        ElseIf NameBlock Like "type_level2" Then
                            booltypeLevel2 = True
                        ElseIf NameBlock Like "name_level2" Then
                            boolnameLevel2 = True
                        ElseIf NameBlock Like "type_level3" Then
                            booltypeLevel3 = True
                        ElseIf NameBlock Like "name_level3" Then
                            boolnameLevel3 = True
                        ElseIf NameBlock Like "readable_address" Then
                            boolreadable_address = True 'неструктурированный адрес
                        ElseIf NameBlock Like "position_description" Then
                            boolposition_description = True 'описание местоположения
                            '===============================================================================
                            'кадастровые номера и обозначения зон
                        ElseIf NameBlock Like "cad_number" Then
                            boolCadNumber = True 'кадастровый номер участка здания стоения ОНС
                        ElseIf NameBlock Like "part_number" Then
                            boolNumberSubParcel = True 'номер части участка
                        ElseIf NameBlock Like "number_pp" Then
                            boolNumberContour = True 'номер контура
                        ElseIf NameBlock Like "reg_numb_border" Then
                            boolRegNumbZone = True 'обозначение границы и ЗОУИТ
                        ElseIf NameBlock Like "common_land_cad_number" Then
                            boolcommon_land_cad_number = True
                            '=================================================================================
                            'площади
                        ElseIf NameBlock Like "area" And boolbase_parameter = False Then
                            boolGlobalArea = True 'площадь объекта
                        ElseIf NameBlock Like "inaccuracy" Then
                            booldeltaArea = True 'погрешность определения площади
                            '====================================================================================
                            'кадастровая стоимость
                        ElseIf NameBlock Like "cost" Then
                            boolCostParcel = True
                            '====================================================================================
                            'тип участка
                        ElseIf NameBlock Like "subtype" Then
                            boolSubTypeParcel = True 'землепользование, обособленный участок и т.п.
                        ElseIf NameBlock Like "category" Then
                            boolCategory = True 'категория земель
                        ElseIf NameBlock Like "permitted_use" Then
                            boolpermitted_use = True
                        ElseIf NameBlock Like "by_document" Then
                            byRazrIspByDoc = True 'разрешенное использование по документу
                        ElseIf NameBlock Like "land_use_mer" Then
                            boolRazrIsp = True 'разрешенное использование по классификатору
                            '=======================================
                            'здания, сооружения (характеристики)
                        ElseIf NameBlock Like "purpose" Then
                            boolpurpose = True 'жилое нежилое многоквартирный дом
                        ElseIf NameBlock Like "permitted_use" Then
                            boolpermitted_use = True 'разрешенное использование, для здания - жилое, нежилое
                            '==============================================
                            'характеристики строения
                        ElseIf NameBlock Like "params" Then
                            boolparams = True 'блок параметров
                        ElseIf NameBlock Like "base_parameter" Then
                            boolbase_parameter = True 'блок с базовыми параметрами
                        ElseIf NameBlock Like "occurence_depth" Then
                            booldepth = True 'глубина
                        ElseIf NameBlock Like "depth" Then
                            booldepth = True 'тоже глубина
                        ElseIf NameBlock Like "extension" Then
                            boolextension = True 'протяженность
                        ElseIf NameBlock Like "volume" Then
                            boolvolume = True 'объем
                        ElseIf NameBlock Like "area" And boolbase_parameter = True Then
                            boolareaConstr = True 'площадь
                        ElseIf NameBlock Like "built_up_area" And boolbase_parameter = True Then
                            boolbuilt_up_area = True 'площадь
                            '=======================================================
                            'территориальные зоны границы
                        ElseIf NameBlock Like "record_info" Then
                            boolrecord_info = True
                        ElseIf NameBlock Like "type_boundary" Then
                            booltype_boundary = True 'тип границы
                        ElseIf NameBlock Like "type_zone" Then
                            boolType_zone = True 'описание зоны
                        ElseIf NameBlock Like "registration_date" Then
                            boolregistration_date = True 'дата регистрации зоны
                        ElseIf NameBlock Like "reg_numb_border" Then
                            boolRegNumbZone = True 'номер зоны
                        ElseIf NameBlock Like "number" And boolzone = True Then
                            boolNumberZona = True 'номер зоны
                        ElseIf NameBlock Like "index" And boolzone = True Then
                            boolIndexZona = True 'номер зоны
                        ElseIf NameBlock Like "description" Then
                            boolDeskZona = True 'номер зоны
                        ElseIf NameBlock Like "name_by_doc" Then
                            boolNameZona = True 'номер зоны
                            '=======================================================
                            'береговые полосы
                        ElseIf NameBlock Like "water_object_type" Then
                            boolwater_object_type = True
                        ElseIf NameBlock Like "water_object_name" Then
                            boolwater_object_name = True
                            '=====================================================================
                            'сведения о правах
                        ElseIf NameBlock Like "right_record" Then
                            boolRightRecords = True 'начало блока, сведения о правах
                        ElseIf NameBlock Like "right_type" Then
                            boolRightType = True 'тип собственности
                        ElseIf NameBlock Like "right_holder" Then
                            boolRight_holder = True 'сведения о правах
                        ElseIf NameBlock Like "name" And boolRight_holder = True Then
                            boolOwnerName = True 'тип собственности
                        ElseIf NameBlock Like "restrict_record" Then
                            boolRestrictRecords = True 'начало блока с арендаторами
                        ElseIf NameBlock Like "resident" Then
                            boolresident = True 'арендатор
                        ElseIf NameBlock Like "foreign_public" Then
                            typeRight = "Собственность иностранного государства"
                        ElseIf NameBlock Like "union_state" Then
                            typeRight = "Собственность союзного государства"
                        ElseIf NameBlock Like "russia" Then
                            typeRight = "Федеральная собственность"
                        ElseIf NameBlock Like "subject_of_rf" Then
                            typeRight = "Собственность субъекта РФ"
                        ElseIf NameBlock Like "municipality" Then
                            typeRight = "Муниципальная собственность"
                        ElseIf NameBlock Like "municipality" Then
                            typeRight = "Муниципальная собственность"
                        ElseIf NameBlock Like "resident" Then
                            typeRight = "Собственность Российского юридического лица"
                        ElseIf NameBlock Like "govement_entity" Then
                            typeRight = "Собственность органа государственной власти или органа местного самоуправления"
                        ElseIf NameBlock Like "not_resident" Then
                            typeRight = "Собственность иностранного юридического лица"
                        ElseIf NameBlock Like "Individual" Then
                            typeRight = "Частная собственность"
                            '=====================================================================
                            'реквизиты выписки
                        ElseIf NameBlock Like "group_top_requisites" Then
                            boolgroup_top_requisites = True 'блок с реквизитами
                        ElseIf NameBlock Like "date_formation" Then
                            booldate_formation = True
                        ElseIf NameBlock Like "registration_number" Then
                            boolregistration_number = True
                            '=============================================================
                            'координаты
                        ElseIf NameBlock Like "ordinate" Then
                            countcoord += 1
                            ReDim Preserve NXYZ(2, countcoord) 'тип,номер, x,y,delta,desk,r
                            NXYZ(0, countcoord) = "0"
                        ElseIf NameBlock Like "x" Then
                            boolX = True
                        ElseIf NameBlock Like "y" Then
                            boolY = True
                        ElseIf NameBlock Like "geopoint_opred" Then
                            boolGeopoint_opred = True
                        ElseIf NameBlock Like "ord_nmb" Then
                            boolOrgNumb = True
                        ElseIf NameBlock Like "num_geopoint" Then
                            boolnum_geopoint = True
                        ElseIf NameBlock Like "delta_geopoint" Then
                            boolDelta = True
                        ElseIf NameBlock Like "r" Then
                            boolR = True
                            '==========================================================================
                            'блоки с объектами
                        ElseIf NameBlock Like "land_record" Then 'земельный участок
                            AddresParcel = ""
                            Cad_Number = ""
                            StateParcel = ""
                            Category = ""
                            CodCategory = ""
                            RazrIsp = ""
                            RazrIspByDoc = ""
                            CostParcel = ""
                            GlobalArea = ""
                            Cad_Number_Note = ""
                            deltaArea = ""
                            RightType = ""
                            encumbranceName = New List(Of String)
                            okato = ""
                            Cad_Number_Short = ""
                            boolParcel = True
                            LocalID = rng.Next
                            GlobalID = 0
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "build_record" Then 'здание
                            Cad_Number = ""
                            AddresParcel = ""
                            okato = ""
                            RightType = ""
                            encumbranceName = New List(Of String)
                            CostParcel = ""
                            GlobalArea = ""
                            Cad_Number_Note = ""
                            purpose_build = ""
                            pos_description_build = ""
                            Assignatuin = ""
                            MaterialWall = ""
                            CountFloat = ""
                            StateParcel = ""
                            boolBuild = True
                            purpose_build = ""
                            Cad_Number_Short = ""
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "construction_record" Then 'конструкция
                            Cad_Number = ""
                            AddresParcel = ""
                            CostParcel = ""
                            GlobalArea = ""
                            Cad_Number_Note = ""
                            baseParameters = ""
                            purpose_construction = ""
                            Cad_Number_Short = ""
                            boolconstruction = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "object_under_construction_record" Then 'объект незавершенного строительсва
                            Cad_Number = ""
                            AddresParcel = ""
                            okato = ""
                            RightType = ""
                            encumbranceName = New List(Of String)
                            CostParcel = ""
                            GlobalArea = ""
                            Cad_Number_Note = ""
                            purpose_build = ""
                            pos_description_build = ""
                            Assignatuin = ""
                            MaterialWall = ""
                            CountFloat = ""
                            StateParcel = ""
                            Cad_Number_Short = ""
                            boolunderconstruction = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "inhabited_locality_boundary_record" Then 'граница населенного пункта
                            RegNumbZone = ""
                            type_boundary = ""
                            cod_boundary = ""
                            registr_data = ""
                            boolcityboundary = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "municipal_boundary_record" Then 'граница административная
                            RegNumbZone = ""
                            type_boundary = ""
                            cod_boundary = ""
                            registr_data = ""
                            boolboundary = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "spatial_data" Then 'квартал
                            boolspatial_data = True
                            boolKvartal = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "zones_and_territories_record" Or NameBlock Like "zones_and_territories" Then 'охранная зона
                            type_zona = ""
                            RegNumbZone = ""
                            code_zona = ""
                            registr_data = ""
                            boolzone = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "coastline_record" Then 'береговая линия
                            type_zona = ""
                            RegNumbZone = ""
                            code_zona = ""
                            registr_data = ""
                            ValTypeObject = ""
                            water_object_name = ""
                            codwater_object_type = ""
                            water_object_type = ""
                            type_boundary = ""
                            boolcoastline = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "public_easement_record" Then 'публичный сервитут
                            type_zona = ""
                            RegNumbZone = ""
                            code_zona = ""
                            registr_data = ""
                            boolzone = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "surveying_project_record" Then 'охранная зона
                            type_zona = ""
                            RegNumbZone = ""
                            code_zona = ""
                            registr_data = ""
                            boolzone = True
                            NumberContour = 0
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                        ElseIf NameBlock Like "land_records" Then
                            ValTypeObject = ""
                            boolNastr = False
                        ElseIf NameBlock Like "build_records" Then
                            ValTypeObject = ""
                            boolNastr = False
                        ElseIf NameBlock Like "construction_records" Then
                            ValTypeObject = ""
                            boolNastr = False
                        ElseIf NameBlock Like "object_under_construction_records" Then
                            ValTypeObject = ""
                            boolNastr = False
                        ElseIf NameBlock Like "municipal_boundaries" Then
                            ValTypeObject = ""
                            boolNastr = False
                        ElseIf NameBlock Like "inhabited_locality_boundaries" Then
                            ValTypeObject = ""
                            cod_boundary = ""
                            boolNastr = False
                        ElseIf NameBlock Like "zones_and_territories_boundaries" Then
                            ValTypeObject = ""
                            code_zona = ""
                            cod_boundary = ""
                            IndexZona = ""
                            NumberZona = ""
                            boolNastr = False
                        ElseIf NameBlock Like "coastline_boundaries" Then
                            boolNastr = False
                        End If
                        '==========================================================================================
                        'значения
                        '==========================================================================================
                    Case XmlNodeType.Text
                        'кадастровый квартал
                        If boolKvartalNumber = True Then 'номер кадастрового квартала
                            CadastralBlock = reader.Value
                            nameKvartal = Replace(CadastralBlock, ":", "_")
                            boolKvartalNumber = False
                        ElseIf boolarea_quarter = True And boolGlobalArea = True Then 'площадь квартала
                            Area_quarter = reader.Value
                        ElseIf boolDateReg = True Then
                            dateReg = reader.Value
                            boolDateReg = False
                        ElseIf boolarea_quarter = True And boolunit = True Then 'еденицы измерения площади квартала
                            Dim unit As Integer = CInt(reader.Value)
                            Area_quarter = Area_quarter & " " '& FuncCadastr.FuncFindCadastrUnitByCode(unit)
                        ElseIf boolcomdata = True And boolType = True Then 'тип объекта (земельный участок, здание и т.п.)
                            CodTypeObject = reader.Value
                            boolType = False
                        ElseIf boolcomdata = True And boolval = True Then
                            ValTypeObject = reader.Value
                            boolval = False
                        ElseIf boolCadNumber = True And boolcomdata = True Then 'кадастровый номер участка, сооружения, здания
                            Cad_Number = reader.Value
                            boolCadNumber = False
                            'отделяем краткий номер
                            Dim posN As Integer = Cad_Number.LastIndexOf(":")
                            If posN > 6 Then
                                Cad_Number_Short = Mid(Cad_Number, posN + 1)
                            End If
                        ElseIf boolCadNumber = True And boolIncluded_object = True Then 'кадастровый номера объектов недвижимости на ЗУ
                            listIncludedObject.Add(reader.Value)
                        ElseIf boolcommon_land_cad_number = True And boolCadNumber = True Then 'кадастровый номер участка, сооружения, здания
                            Cad_Number_Note = reader.Value
                            boolCadNumber = False
                        ElseIf boolNumberSubParcel = True Then 'номер части учаcтка
                            NumberSubParcel = reader.Value
                            boolNumberSubParcel = False
                        ElseIf boolNumberContour = True Then 'номер контура
                            NumberContour = Val(reader.Value)
                            boolNumberContour = False
                        ElseIf boolRegNumbZone = True Then 'номер территориальной зоны
                            RegNumbZone = reader.Value
                            boolRegNumbZone = False
                        ElseIf boolSubTypeParcel = True And boolval = True Then 'тип участка 01-землепользование, многоконтурный и т.п.
                            SubTypeParcel = reader.Value
                            If SubTypeParcel Like "Многоконтурный участок" Or SubTypeParcel Like "Единое землепользование" Then
                                GlobalID = rng.Next
                            Else
                                GlobalID = 0
                            End If
                            boolSubTypeParcel = False
                        ElseIf boolStateParcel = True And boolCode = True Then 'статус участка
                            StateParcel = reader.Value
                        ElseIf boolCategory = True And boolCode = True Then 'категория земель
                            CodCategory = reader.Value
                        ElseIf boolCategory = True And boolval = True Then
                            Category = reader.Value
                        ElseIf boolpermitted_use = True And byRazrIspByDoc = True Then 'разрешенное использование по документу
                            RazrIspByDoc = reader.Value
                            byRazrIspByDoc = False
                        ElseIf boolpermitted_use = True And boolRazrIsp = True Then 'разрешенное использование по документу
                            RazrIsp = reader.Value
                            boolRazrIsp = False
                        ElseIf boolCostParcel = True And boolval = True Then 'кадастровая стоимость
                            CostParcel = reader.Value
                            boolCostParcel = False
                        ElseIf boolPart = True And boolGlobalArea = True And boolval = True And boolType = False Then 'площадь части
                            areaPart = reader.Value
                        ElseIf boolGlobalArea = True And boolval = True And boolType = False Then 'площадь участка
                            GlobalArea = reader.Value
                        ElseIf boolparams = True And boolGlobalArea = True And boolParcel = False Then 'площадь здания
                            GlobalArea = reader.Value
                        ElseIf boolGlobalArea = True And booldeltaArea = True Then 'погрешность площади
                            deltaArea = reader.Value
                            booldeltaArea = False
                            '========================================================================
                            'адрес
                        ElseIf boolAdresParcel = True And boolokato = True Then
                            okato = reader.Value
                            boolokato = False
                        ElseIf boolAdresParcel = True And boolkladr = True Then
                            kladr = reader.Value
                            boolkladr = False
                        ElseIf boolAdresParcel = True And boolpostcode = True Then
                            postcode = reader.Value
                            boolpostcode = False
                        ElseIf boolAdresParcel = True And boolregion = True And boolval = True Then
                            region = reader.Value
                            boolregion = False
                            boolval = False
                        ElseIf boolAdresParcel = True And booltypeDistrict = True Then
                            typeDistrict = reader.Value
                            booltypeDistrict = False
                        ElseIf boolAdresParcel = True And boolnameDistrict = True Then
                            nameDistrict = reader.Value
                            boolnameDistrict = False
                        ElseIf boolAdresParcel = True And booltypeLocality = True Then
                            typeLocality = reader.Value
                            booltypeLocality = False
                        ElseIf boolAdresParcel = True And boolnameLocality = True Then
                            nameLocalyty = reader.Value
                            boolnameLocality = False
                        ElseIf boolAdresParcel = True And booltypeStreet = True Then
                            type_street = reader.Value
                            booltypeStreet = False
                        ElseIf boolAdresParcel = True And boolnameStreet = True Then
                            name_street = reader.Value
                            boolnameStreet = False
                        ElseIf boolAdresParcel = True And booltypeLevel1 = True Then
                            typeLevel1 = reader.Value
                            booltypeLevel1 = False
                        ElseIf boolAdresParcel = True And boolnameLevel1 = True Then
                            nameLevel1 = reader.Value
                            boolnameLevel1 = False
                        ElseIf boolAdresParcel = True And booltypeLevel2 = True Then
                            typeLevel2 = reader.Value
                            booltypeLevel2 = False
                        ElseIf boolAdresParcel = True And boolnameLevel2 = True Then
                            nameLevel2 = reader.Value
                            boolnameLevel2 = False
                        ElseIf boolAdresParcel = True And booltypeLevel3 = True Then
                            typeLevel3 = reader.Value
                            booltypeLevel3 = False
                        ElseIf boolAdresParcel = True And boolnameLevel3 = True Then
                            nameLevel3 = reader.Value
                            boolnameLevel3 = False
                        ElseIf boolreadable_address = True Then
                            readable_address = reader.Value
                            boolreadable_address = False
                            '============================================================================
                            'сведения о правах
                        ElseIf boolRightType = True And boolRightRecords = True And boolval = True Then 'вид права
                            RightType = reader.Value
                            boolRightType = False
                            boolval = False
                        ElseIf boolRight_holder = True And boolname = True And boolRightRecords = True And boolCode = False Then 'наименование владельца
                            ownerName = reader.Value
                        ElseIf boolRight_holder = True And boolval = True And boolRightRecords = True And boolCode = False Then 'наименование владельца
                            ownerName = reader.Value
                        ElseIf boolRestrictRecords = True And boolresident = True And boolname = True Then 'наименорвание арендаторов и др.
                            encumbranceName.Add(reader.Value)
                            boolresident = False
                            '============================================================
                            'здания
                        ElseIf boolpurpose = True And boolval = True And boolparams = True Then
                            purpose_build = reader.Value 'назначение
                            boolval = False
                        ElseIf boolpurpose = True And boolname = True Then
                            purpose_build = reader.Value 'назначение
                            boolname = False
                        ElseIf boolpurpose = True And boolCode = True And boolparams = True Then
                            codeBuild = reader.Value 'код здания
                            boolCode = False
                        ElseIf boolposition_description = True Then
                            pos_description_build = reader.Value 'описание местоположения
                            boolposition_description = False
                        ElseIf boolpermitted_use = True And boolname = True Then
                            permitted_use = reader.Value
                            '===================================================================
                            'сооружения
                        ElseIf boolparams = True And boolpurpose = True Then
                            purpose_construction = reader.Value
                            boolpurpose = False
                        ElseIf boolbase_parameter = True And boolextension = True Then
                            baseParameters = baseParameters & "Длина " & reader.Value & " "
                            boolextension = False
                        ElseIf boolbase_parameter = True And booldepth = True Then
                            baseParameters = baseParameters & "Глубина " & reader.Value & " "
                            booldepth = False
                        ElseIf boolbase_parameter = True And booldepth = True Then
                            baseParameters = baseParameters & "Глубина " & reader.Value & " "
                            booldepth = False
                        ElseIf boolbase_parameter = True And boolvolume = True Then
                            baseParameters = baseParameters & "Объем " & reader.Value & " "
                            boolvolume = False
                        ElseIf boolbase_parameter = True And boolareaConstr = True Then
                            baseParameters = baseParameters & "Общая площадь " & reader.Value & " "
                            boolareaConstr = False
                        ElseIf boolbase_parameter = True And boolbuilt_up_area = True Then
                            baseParameters = baseParameters & "Общая площадь застройки " & reader.Value & " "
                            boolbuilt_up_area = False
                            '=======================================================================
                            'границы
                        ElseIf booltype_boundary = True And boolval = True Then
                            type_boundary = reader.Value
                            boolval = False
                        ElseIf booltype_boundary = True And boolCode = True Then
                            cod_boundary = reader.Value
                            boolCode = False
                            'береговые линии
                        ElseIf boolwater_object_type = True And boolCode = True Then
                            codwater_object_type = reader.Value
                            boolCode = False
                        ElseIf boolwater_object_type = True And boolType = True Then
                            water_object_type = reader.Value
                            boolType = False
                        ElseIf boolwater_object_type = True And boolval = True Then
                            water_object_type = reader.Value
                            boolval = False
                        ElseIf boolwater_object_name = True Then
                            water_object_name = reader.Value
                            boolwater_object_name = False
                            '==============================================================================
                            'территориальные зоны
                        ElseIf boolregistration_date = True And boolrecord_info = True Then
                            registr_data = reader.Value
                            boolregistration_date = False
                        ElseIf boolType_zone = True And boolval = True Then 'тип ЗОУИТ
                            type_zona = reader.Value
                            boolval = False
                        ElseIf boolType_zone = True And boolCode = True Then 'код ЗОУИТ
                            code_zona = reader.Value
                            boolCode = False
                        ElseIf boolRegNumbZone = True Then
                            RegNumbZone = reader.Value
                            boolRegNumbZone = False
                        ElseIf boolzone = True And boolIndexZona = True Then 'индекс зоны
                            IndexZona = reader.Value
                            boolIndexZona = False
                        ElseIf boolzone = True And boolNumberZona = True Then 'номер зоны
                            NumberZona = reader.Value
                            boolNumberZona = False
                        ElseIf boolNameZona = True Then
                            name_by_doc = reader.Value
                            boolNameZona = False
                        ElseIf boolDeskZona = True Then
                            deskZona = reader.Value
                            boolDeskZona = False
                            'координаты точек
                            '======================================================================================
                        ElseIf boolOrgNumb = True Then
                            'If IsArray(NXYZ) = True Then
                            '    NXYZ(1, countcoord) = reader.Value 'номер точки
                            '    OrgNumb = reader.Value
                            'End If
                            boolOrgNumb = False
                        ElseIf boolX = True Then
                            If IsArray(NXYZ) = True Then
                                NXYZ(2, countcoord) = reader.Value 'X
                                X = reader.Value
                            End If
                            boolX = False
                        ElseIf boolY = True Then
                            If IsArray(NXYZ) = True Then
                                NXYZ(1, countcoord) = reader.Value 'Y
                                Y = reader.Value
                            End If
                            boolY = False
                        ElseIf boolDelta = True Then
                            'If IsArray(NXYZ) = True Then
                            '    NXYZ(4, countcoord) = reader.Value 'Delta
                            '    Delta = reader.Value
                            'End If
                            boolDelta = False
                        ElseIf boolnum_geopoint = True Then
                            'If IsArray(NXYZ) = True Then
                            '    NXYZ(5, countcoord) = reader.Value 'старый номер
                            'End If
                            boolnum_geopoint = False
                        ElseIf boolgeopoint_zacrep = True Then
                            'If IsArray(NXYZ) = True Then
                            '    NXYZ(6, countcoord) = reader.Value 'тип закрепления
                            'End If
                            boolnum_geopoint = False
                        ElseIf boolGeopoint_opred = True And boolval = True Then
                            'If IsArray(NXYZ) = True Then
                            '    NXYZ(7, countcoord) = reader.Value
                            'End If
                            boolGeopointValue = False
                        ElseIf boolR = True Then
                            If IsArray(NXYZ) = True Then
                                NXYZ(0, countcoord) = reader.Value
                            End If
                            boolR = False
                            '===================================================================================
                            'реквизиты выписки
                        ElseIf booldate_formation = True Then
                            dataVP = reader.Value
                            booldate_formation = False
                        ElseIf boolregistration_number = True Then
                            NumberVP = reader.Value
                            boolregistration_number = False
                        End If
                                    '====================================================================================================
                                    'блоки закрытия
                    Case XmlNodeType.EndElement
                        '=======================================================================
                        'блок общих данных
                        If NameBlock Like "common_data" Then
                            boolcomdata = False
                        ElseIf NameBlock Like "code" Then
                            boolCode = False
                        ElseIf NameBlock Like "value" Then
                            boolval = False
                        ElseIf NameBlock Like "type" Then
                            boolType = False
                        ElseIf NameBlock Like "unit" Then
                            boolunit = False
                        ElseIf NameBlock Like "name" Then
                            boolname = False
                        ElseIf NameBlock Like "included_object" Then
                            boolIncluded_object = False
                            '=========================================================
                        ElseIf NameBlock Like "area_quarter" Then
                            boolarea_quarter = False
                        ElseIf NameBlock Like "group_top_requisites" Then
                            boolgroup_top_requisites = False
                        ElseIf NameBlock Like "cad_number" Then
                            boolCadNumber = False
                        ElseIf NameBlock Like "common_land_cad_number" Then
                            boolcommon_land_cad_number = False
                        ElseIf NameBlock Like "subtype" Then
                            boolSubTypeParcel = False
                        ElseIf NameBlock Like "State" Then
                            boolStateParcel = False
                        ElseIf NameBlock Like "category" Then
                            boolCategory = False
                        ElseIf NameBlock Like "permitted_use" Then
                            boolRazrIsp = False
                        ElseIf NameBlock Like "cost" Then
                            boolCostParcel = False
                        ElseIf NameBlock Like "area" Then
                            boolGlobalArea = False
                            '=========================================================
                            'адрес
                        ElseIf NameBlock Like "address" Then
                            boolAdresParcel = False
                            If okato.Trim.Length > 0 Then
                                AddresParcel = "ОКАТО " & okato & " "
                                okato = ""
                            End If
                            If kladr.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & "КЛАДР " & kladr & " "
                                kladr = ""
                            End If
                            If postcode.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & "Индекс " & postcode & " "
                                postcode = ""
                            End If
                            If region.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & region & " "
                                region = ""
                            End If
                            If typeDistrict.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & typeDistrict & " "
                                typeDistrict = ""
                            End If
                            If nameDistrict.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & nameDistrict & " "
                                nameDistrict = ""
                            End If
                            If typeLocality.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & typeLocality & " "
                                typeLocality = ""
                            End If
                            If nameLocalyty.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & nameLocalyty & " "
                                nameLocalyty = ""
                            End If
                            If type_street.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & type_street & " "
                                type_street = ""
                            End If
                            If name_street.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & name_street & " "
                                name_street = ""
                            End If
                            If typeLevel1.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & typeLevel1 & " "
                                typeLevel1 = ""
                            End If
                            If nameLevel1.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & nameLevel1 & " "
                                nameLevel1 = ""
                            End If
                            If typeLevel2.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & typeLevel2 & " "
                                typeLevel2 = ""
                            End If
                            If nameLevel2.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & nameLevel2 & " "
                                nameLevel2 = ""
                            End If
                            If typeLevel3.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & typeLevel3 & " "
                                typeLevel3 = ""
                            End If
                            If nameLevel3.Trim.Length > 0 Then
                                AddresParcel = AddresParcel & nameLevel3 & " "
                                nameLevel3 = ""
                            End If
                        ElseIf NameBlock Like "okato" Then
                            boolokato = False
                        ElseIf NameBlock Like "kladr" Then
                            boolkladr = False
                        ElseIf NameBlock Like "region" Then
                            boolregion = False
                        ElseIf NameBlock Like "type_district" Then
                            booltypeDistrict = False
                        ElseIf NameBlock Like "name_district" Then
                            boolnameDistrict = False
                        ElseIf NameBlock Like "type_locality" Then
                            booltypeLocality = False
                        ElseIf NameBlock Like "name_locality" Then
                            boolnameLocality = False
                        ElseIf NameBlock Like "type_street" Then
                            booltypeStreet = False
                        ElseIf NameBlock Like "name_street" Then
                            boolnameStreet = False
                        ElseIf NameBlock Like "type_level1" Then
                            booltypeLevel1 = False
                        ElseIf NameBlock Like "name_level1" Then
                            boolnameLevel1 = False
                        ElseIf NameBlock Like "type_level2" Then
                            booltypeLevel2 = False
                        ElseIf NameBlock Like "name_level2" Then
                            boolnameLevel2 = False
                        ElseIf NameBlock Like "type_level3" Then
                            booltypeLevel3 = False
                        ElseIf NameBlock Like "name_level3" Then
                            boolnameLevel3 = False
                            '============================================================================
                        ElseIf NameBlock Like "purpose" Then
                            boolpurpose = False
                        ElseIf NameBlock Like "params" Then
                            boolparams = False
                        ElseIf NameBlock Like "permitted_use" Then
                            boolpermitted_use = False
                        ElseIf NameBlock Like "base_parameter" Then
                            boolbase_parameter = False
                        ElseIf NameBlock Like "type_boundary" Then
                            booltype_boundary = False
                        ElseIf NameBlock Like "type_zone" Then
                            boolType_zone = False
                        ElseIf NameBlock Like "record_info" Then
                            boolrecord_info = False
                        ElseIf NameBlock Like "registration_date" Then
                            boolregistration_date = False 'дата регистрации зоны
                        ElseIf NameBlock Like "number_pp" Then 'номер контура
                            boolNumberContour = False
                        ElseIf NameBlock Like "area" Then
                            boolGlobalArea = False
                        ElseIf NameBlock Like "spatials_elements" Then
                            boolSpatialElements = False
                        ElseIf NameBlock Like "geopoint_opred" Then
                            boolGeopoint_opred = False
                        ElseIf NameBlock Like "x" Then
                            boolX = False
                        ElseIf NameBlock Like "y" Then
                            boolY = False
                        ElseIf NameBlock Like "geopoint_opred" Then
                            boolGeopoint_opred = False
                        ElseIf NameBlock Like "ord_nmb" Then
                            boolOrgNumb = False
                        ElseIf NameBlock Like "num_geopoint" Then
                            boolnum_geopoint = False
                        ElseIf NameBlock Like "delta_geopoint" Then
                            boolDelta = False
                        ElseIf NameBlock Like "r" Then
                            boolR = False
                        ElseIf NameBlock Like "restrict_record" Then
                            boolRestrictRecords = False
                        ElseIf NameBlock Like "right_record" Then
                            boolRightRecords = False
                        ElseIf NameBlock Like "right_holder" Then
                            boolRight_holder = False
                            '===================================================================================================
                            'конец блока с координатами контура
                        ElseIf NameBlock Like "spatial_element" Then
                            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                            'вставляем полилинию или окружность в качестве объекта
                            If IsArray(NXYZ) = True Then
                                If listCoord.Count = 0 Then
                                    Dim listCounter As List(Of String(,)) = New List(Of String(,))
                                    listCounter.Add(NXYZ)
                                    If NumberSubParcel > 0 Then
                                        listCoord.Add(NumberSubParcel, listCounter)
                                    Else
                                        listCoord.Add(NumberContour, listCounter)
                                    End If
                                Else
                                    If NumberSubParcel > 0 Then
                                        If listCoord.ContainsKey(NumberSubParcel) = True Then
                                            Dim listCounter As List(Of String(,)) = listCoord.Item(NumberSubParcel)
                                            listCounter.Add(NXYZ)
                                            listCoord.Item(NumberSubParcel) = listCounter
                                        Else
                                            Dim listCounter As List(Of String(,)) = New List(Of String(,))
                                            listCounter.Add(NXYZ)
                                            listCoord.Add(NumberSubParcel, listCounter)
                                        End If
                                    Else
                                        If listCoord.ContainsKey(NumberContour) = True Then
                                            Dim listCounter As List(Of String(,)) = listCoord.Item(NumberContour)
                                            listCounter.Add(NXYZ)
                                            listCoord.Item(NumberContour) = listCounter
                                        Else
                                            Dim listCounter As List(Of String(,)) = New List(Of String(,))
                                            listCounter.Add(NXYZ)
                                            listCoord.Add(NumberContour, listCounter)
                                        End If
                                    End If
                                End If
                                Erase NXYZ
                                countcoord = -1
                            End If
                        ElseIf NameBlock Like "land_record" Then
                            boolParcel = False
                            Dim userParcel As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userParcel.Add("LABEL", "Кадастровый участок учтенный")
                            userParcel.Add("PS", "LAND_CADASTRAL_PARCEL")
                            userParcel.Add("NameTypeObject", StructureElement.nameObject.CadastralParcel)
                            userParcel.Add("Cad_number", Cad_Number)
                            userParcel.Add("Short_cad_number", Cad_Number_Short)
                            userParcel.Add("ParentCadNumber", Cad_Number_Note)
                            userParcel.Add("Type", ValTypeObject)
                            userParcel.Add("State", SubTypeParcel)
                            userParcel.Add("Area", GlobalArea)
                            userParcel.Add("Inaccuracy", deltaArea)
                            userParcel.Add("Address", readable_address)
                            userParcel.Add("Category", Category)
                            userParcel.Add("Utilization", RazrIsp)
                            userParcel.Add("UtilizationByDoc", RazrIspByDoc)
                            userParcel.Add("CadastralCost", CostParcel)
                            If listIncludedObject.Count > 0 Then
                                Dim str As String = ""
                                For i As Integer = 0 To listIncludedObject.Count - 1
                                    str = str & listIncludedObject(i) & " "
                                Next
                                userParcel.Add("RealObject", str)
                            Else
                                userParcel.Add("RealObject", "")
                            End If
                            userParcel.Add("Right", RightType)
                            userParcel.Add("Patronymic", ownerName)
                            userParcel.Add("Encumbrance", encumbranceName)
                            userParcel.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userParcel)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim cadN As String = Cad_Number_Short.Replace(":", "")
                            filePath = tempDirectory & "\parcel" & countObject & "_" & cadN & ".json"
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            Cad_Number = ""
                            Cad_Number_Short = ""
                            Cad_Number_Note = ""
                            ValTypeObject = ""
                            StateParcel = ""
                            GlobalArea = ""
                            deltaArea = ""
                            okato = ""
                            readable_address = ""
                            Category = ""
                            RazrIspByDoc = ""
                            CostParcel = ""
                            RightType = ""
                            ownerName = ""
                            encumbranceName = New List(Of String)
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                        ElseIf NameBlock Like "build_record" Then
                            boolBuild = False
                            Dim userBuild As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userBuild.Add("LABEL", "Здание (строение)")
                            userBuild.Add("PS", "LAND_CADASTRAL_BUILDING")
                            userBuild.Add("NameTypeObject", StructureElement.nameObject.CadastralBilding)
                            userBuild.Add("Cad_number", Cad_Number)
                            userBuild.Add("Short_cad_number", Cad_Number_Short)
                            userBuild.Add("Type", ValTypeObject)
                            userBuild.Add("Purpose", purpose_build)
                            userBuild.Add("Assignation", Assignatuin)
                            userBuild.Add("MaterialWall", baseParameters)
                            userBuild.Add("FloatCount", CountFloat)
                            userBuild.Add("Area", GlobalArea)
                            userBuild.Add("Address", readable_address)
                            userBuild.Add("CadastralCost", CostParcel)
                            userBuild.Add("Right", RightType)
                            userBuild.Add("Patronymic", ownerName)
                            userBuild.Add("Encumbrance", encumbranceName)
                            userBuild.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userBuild)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim cadN As String = Cad_Number_Short.Replace(":", "")
                            filePath = tempDirectory & "\build" & countObject & "_" & cadN & ".json"
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            Cad_Number = ""
                            Cad_Number_Short = ""
                            ValTypeObject = ""
                            purpose_build = ""
                            Assignatuin = ""
                            MaterialWall = ""
                            CountFloat = ""
                            okato = ""
                            GlobalArea = ""
                            readable_address = ""
                            baseParameters = ""
                            CostParcel = ""
                            RightType = ""
                            ownerName = ""
                            encumbranceName = New List(Of String)
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                        ElseIf NameBlock Like "construction_record" Then
                            boolconstruction = False
                            Dim userConstruction As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userConstruction.Add("LABEL", "Сооружение")
                            userConstruction.Add("PS", "LAND_CADASTRAL_CONSTRUCTION")
                            userConstruction.Add("NameTypeObject", StructureElement.nameObject.Construction)
                            userConstruction.Add("Cad_number", Cad_Number)
                            userConstruction.Add("Short_cad_number", Cad_Number_Short)
                            userConstruction.Add("KeyParameter", baseParameters)
                            userConstruction.Add("Assignation", purpose_construction)
                            userConstruction.Add("Address", readable_address)
                            userConstruction.Add("CadastralCost", CostParcel)
                            userConstruction.Add("Right", RightType)
                            userConstruction.Add("Patronymic", ownerName)
                            userConstruction.Add("Encumbrance", encumbranceName)
                            userConstruction.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userConstruction)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim cadN As String = Cad_Number_Short.Replace(":", "")
                            filePath = tempDirectory & "\constr" & countObject & "_" & cadN & ".json"
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            Cad_Number = ""
                            Cad_Number_Short = ""
                            baseParameters = ""
                            purpose_construction = ""
                            okato = ""
                            encumbranceName = New List(Of String)
                            readable_address = ""
                            CostParcel = ""
                            RightType = ""
                            ownerName = ""
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "object_under_construction_record" Then
                            boolunderconstruction = False
                            Dim userBuild As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userBuild.Add("LABEL", "Объект незавершенного строительства")
                            userBuild.Add("PS", "LAND_CADASTRAL_UNFINISHED_CONSTRUCTION")
                            userBuild.Add("NameTypeObject", StructureElement.nameObject.CadastralUnderConstruction)
                            userBuild.Add("Cad_number", Cad_Number)
                            userBuild.Add("Short_cad_number", Cad_Number_Short)
                            userBuild.Add("Purpose", purpose_construction)
                            userBuild.Add("Address", readable_address)
                            userBuild.Add("KeyParameter", baseParameters)
                            userBuild.Add("CadastralCost", CostParcel)
                            userBuild.Add("Right", RightType)
                            userBuild.Add("Patronymic", ownerName)
                            userBuild.Add("Encumbrance", encumbranceName)
                            userBuild.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userBuild)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim cadN As String = Cad_Number_Short.Replace(":", "")
                            filePath = tempDirectory & "\uconstr" & countObject & "_" & cadN & ".json"
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            Cad_Number = ""
                            Cad_Number_Short = ""
                            purpose_build = ""
                            GlobalArea = ""
                            readable_address = ""
                            okato = ""
                            baseParameters = ""
                            CostParcel = ""
                            RightType = ""
                            ownerName = ""
                            encumbranceName = New List(Of String)
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "municipal_boundary_record" Or NameBlock Like "inhabited_locality_boundary_record" Then
                            boolboundary = False
                            Dim userBound As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userBound.Add("LABEL", "Административная граница")
                            userBound.Add("PS", "LAND_CADASTRAL_BOUNDARY")
                            If NameBlock Like "municipal_boundary_record" Then
                                userBound.Add("NameTypeObject", StructureElement.nameObject.MunicipalBoundary)
                            ElseIf NameBlock Like "inhabited_locality_boundary_record" Then
                                userBound.Add("NameTypeObject", StructureElement.nameObject.SettlementBoundary)
                            End If
                            userBound.Add("Reg_numb_border", RegNumbZone)
                            userBound.Add("Name", "")
                            userBound.Add("Type_boundary", type_boundary)
                            userBound.Add("ID_numb_border", NumberZona)
                            userBound.Add("DateRegistration", dateReg)
                            userBound.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userBound)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim condBorder As String = RegNumbZone.Replace(":", "_")
                            condBorder = condBorder.Replace(".", "_")
                            condBorder = condBorder & ".json"
                            filePath = tempDirectory & "\bound" & countObject & "_" & condBorder
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            RegNumbZone = ""
                            type_boundary = ""
                            registr_data = ""
                            NumberZona = ""
                            dateReg = ""
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "zones_and_territories_record" Then
                            boolzone = False
                            Dim userZona As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userZona.Add("LABEL", type_boundary)
                            userZona.Add("PS", "LAND_CADASTRAL_ZONE")
                            If type_boundary Like "Территориальная зона" Then
                                userZona.Add("NameTypeObject", StructureElement.nameObject.TerritorialZona)
                            ElseIf type_boundary Like "Зона с особыми условиями использования территории" Then
                                userZona.Add("NameTypeObject", StructureElement.nameObject.SpecialZona)
                            ElseIf type_boundary Like "Граница зоны с особыми условиями использования территории" Then
                                userZona.Add("NameTypeObject", StructureElement.nameObject.SpecialZona)
                            ElseIf type_boundary Like "Граница лесничества" Then
                                userZona.Add("NameTypeObject", StructureElement.nameObject.ForestryBoundary)
                            ElseIf type_boundary Like "Зона публичного сервитута" Then
                                userZona.Add("NameTypeObject", StructureElement.nameObject.PublicEasement)
                            ElseIf type_boundary Like "Граница публичного сервитута" Then
                                userZona.Add("NameTypeObject", StructureElement.nameObject.PublicEasement)
                            End If
                            userZona.Add("Reg_numb_border", RegNumbZone)
                            userZona.Add("Type_zone", type_zona)
                            userZona.Add("Type_boundary", type_boundary)
                            userZona.Add("Name_by_doc", name_by_doc)
                            userZona.Add("Description", deskZona)
                            userZona.Add("Index", IndexZona)
                            userZona.Add("Number", NumberZona)
                            userZona.Add("ContentRestrictions", "")
                            userZona.Add("DateRegistration", dateReg)
                            userZona.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userZona)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim condBorder As String = RegNumbZone.Replace(":", "_")
                            condBorder = condBorder.Replace(".", "_")
                            condBorder = condBorder & ".json"
                            filePath = tempDirectory & "\zone" & countObject & "_" & condBorder
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            type_boundary = ""
                            RegNumbZone = ""
                            type_zona = ""
                            deskZona = ""
                            name_by_doc = ""
                            IndexZona = ""
                            NumberZona = ""
                            registr_data = ""
                            dateReg = ""
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "spatial_data" Then
                            'кадастровый квартал
                            boolspatial_data = False
                            Dim userDivision As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userDivision.Add("LABEL", "Граница кадастрового квартала")
                            userDivision.Add("PS", "LAND_CADASTRAL_DIVISION")
                            userDivision.Add("NameTypeObject", StructureElement.nameObject.CadastralDivision)
                            userDivision.Add("Cadastral_number", CadastralBlock)
                            userDivision.Add("Area", Area_quarter)
                            userDivision.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userDivision)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            filePath = tempDirectory & "\kvartal" & countObject & ".json"
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            CadastralBlock = ""
                            Area_quarter = ""
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                            '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                            'береговые линии
                        ElseIf NameBlock Like "coastline_record" Then
                            boolcoastline = False
                            Dim userCoatLine As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userCoatLine.Add("LABEL", "Береговая линия (граница водного объекта)")
                            userCoatLine.Add("PS", "LAND_CADASTRAL_COASTLINE")
                            userCoatLine.Add("NameTypeObject", StructureElement.nameObject.WaterBoundary)
                            userCoatLine.Add("Reg_numb_border", RegNumbZone)
                            userCoatLine.Add("Water_object_type", water_object_type)
                            userCoatLine.Add("Water_object_name", water_object_name)
                            userCoatLine.Add("DateRegistration", dateReg)
                            userCoatLine.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userCoatLine)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim condBorder As String = RegNumbZone.Replace(":", "_")
                            condBorder = condBorder.Replace(".", "_")
                            condBorder = condBorder & ".json"
                            filePath = tempDirectory & "\coast" & countObject & "_" & condBorder
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            RegNumbZone = ""
                            water_object_name = ""
                            water_object_type = ""
                            registr_data = ""
                            dateReg = ""
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "public_easement_record" Then
                            boolcoastline = False
                            Dim userBound As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userBound.Add("LABEL", "Зона публичного сервитута")
                            userBound.Add("PS", "LAND_CADASTRAL_BOUNDARY")
                            userBound.Add("NameTypeObject", StructureElement.nameObject.PublicEasement)
                            userBound.Add("Reg_numb_border", RegNumbZone)
                            userBound.Add("Name", "")
                            userBound.Add("Type_boundary", type_boundary)
                            userBound.Add("DateRegistration", dateReg)
                            userBound.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userBound)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim condBorder As String = RegNumbZone.Replace(":", "_")
                            condBorder = condBorder.Replace(".", "_")
                            condBorder = condBorder & ".json"
                            filePath = tempDirectory & "\eastment" & countObject & "_" & condBorder
                            Using fs As New FileStream(filePath, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            RegNumbZone = ""
                            type_boundary = ""
                            registr_data = ""
                            dateReg = ""
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "object_part" Then
                            boolPart = False
                            Dim userPart As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                            userPart.Add("LABEL", "Часть кадастрового участка")
                            userPart.Add("PS", "LAND_CADASTRAL_PART")
                            userPart.Add("NameTypeObject", StructureElement.nameObject.CadastralPartParcel)
                            userPart.Add("Cad_number", Cad_Number)
                            userPart.Add("Part_number", NumberSubParcel)
                            userPart.Add("Desk", "")
                            userPart.Add("Area", areaPart)
                            userPart.Add("Encumbrance", encumbranceName)
                            userPart.Add("ListCoord", listCoord)
                            Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userPart)
                            Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonString)
                            ' Запись в двоичный файл
                            Dim filePathPart As String = tempDirectory & "\part" & countObject & ".json"
                            Using fs As New FileStream(filePathPart, FileMode.Create, FileAccess.Write)
                                fs.Write(jsonBytes, 0, jsonBytes.Length)
                            End Using
                            NumberSubParcel = 0
                            encumbranceName = New List(Of String)
                            listCoord = New Dictionary(Of Integer, List(Of String(,)))
                            countObject += 1
                        ElseIf NameBlock Like "water_object_type" Then
                            boolwater_object_type = False
                            Erase ObjectCollections
                        ElseIf NameBlock Like "water_object_name" Then
                            boolwater_object_name = False
                            Erase ObjectCollections
                        ElseIf NameBlock Like "extract_cadastral_plan_territory" Then
                            Erase ObjectCollections
                        ElseIf NameBlock Like "land_records" Then
                            CodCategory = ""
                            Erase ObjectCollections
                        End If
                End Select
            End While
            'формируем сведения о правах
            If typeRight.Trim.Length > 0 Then
                userRight.Add("Right", typeRight)
            Else
                If RightType.Trim.Length > 0 Then
                    userRight.Add("Right", RightType)
                Else
                    userRight.Add("Right", "Государственная собственность")
                End If
            End If
            If ownerName.Trim.Length > 0 Then
                userRight.Add("Patronymic", ownerName)
            End If
            If encumbranceName.Count > 0 Then
                Dim str As String = ""
                For Each enk As String In encumbranceName
                    If str.Length = 0 Then
                        str = enk
                    Else
                        str = str & ", " & enk
                    End If
                Next
                userRight.Add("Encumbrance", str)
            End If
            If userRight.Count > 0 Then
                If File.Exists(filePath) = True Then
                    Dim jsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(userRight)
                    ' Добавляем символ перевода строки в КОНЕЦ строки
                    Dim jsonWithNewLine As String = Environment.NewLine & jsonString
                    Dim jsonBytes As Byte() = Encoding.UTF8.GetBytes(jsonWithNewLine)  ' ← ЗДЕСЬ БЫЛА ОШИБКА
                    Using fs As New FileStream(filePath, FileMode.Append, FileAccess.Write)
                        fs.Write(jsonBytes, 0, jsonBytes.Length)
                    End Using
                End If
            End If
        Catch ex As System.Exception
            MsgBox(ex.ToString & vbLf & "Ошибка обработки данных. Макро прервано." & vbLf & LineErrNumber)
            Exit Sub
        End Try
    End Sub
End Class


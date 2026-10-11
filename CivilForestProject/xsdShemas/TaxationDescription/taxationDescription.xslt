<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:agegr="http://rosleshoz.gov.ru/fgis-lk/common/enums/ageGroup/types/2.0"
                xmlns:sub="http://rosleshoz.gov.ru/fgis-lk/common/subject/types/2.1"
                xmlns:st="http://rosleshoz.gov.ru/fgis-lk/common/simple/types/2.0"
                xmlns:addr="http://rosleshoz.gov.ru/fgis-lk/common/address/types/2.0"
                xmlns:country="http://rosleshoz.gov.ru/fgis-lk/common/enums/country/types/2.0"
                xmlns:cmplx="http://rosleshoz.gov.ru/fgis-lk/common/complex/types/2.0"
                xmlns:subjrf="http://rosleshoz.gov.ru/fgis-lk/common/enums/constituentEntity/types/2.0"
                xmlns:doc="http://rosleshoz.gov.ru/fgis-lk/common/document/types/2.1"
                xmlns:att="http://rosleshoz.gov.ru/fgis-lk/common/attachment/types/2.0"
                xmlns:catland="http://rosleshoz.gov.ru/fgis-lk/common/enums/categoryLand/types/2.0"
                xmlns:mozvl="http://rosleshoz.gov.ru/fgis-lk/common/enums/measuresOZVL/types/2.0"
                xmlns:tforfire="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeForestFire/types/2.0"
                xmlns:cut="http://rosleshoz.gov.ru/fgis-lk/common/enums/cuttingType/types/2.0"
                xmlns:roadt="http://rosleshoz.gov.ru/fgis-lk/common/enums/roadType/types/2.0"
                xmlns:fakt="http://rosleshoz.gov.ru/fgis-lk/common/enums/forestryActivities/types/2.1"
                xmlns:soil="http://rosleshoz.gov.ru/fgis-lk/common/enums/soilTypes/types/2.0"
                xmlns:catforest="http://rosleshoz.gov.ru/fgis-lk/common/enums/categoryLandForestry/types/2.0"
                xmlns:ns0="http://rosleshoz.gov.ru/fgis-lk/taxationDescription/types/2.0.0"
                xmlns:contour="http://rosleshoz.gov.ru/fgis-lk/common/popdContoursLocation/types/0.2.0"
                xmlns:sfre="http://rosleshoz.gov.ru/fgis-lk/common/stateForestRegisterExtract/types/2.1"
                xmlns:unitMeasurement="http://rosleshoz.gov.ru/fgis-lk/common/enums/unitMeasurement/types/2.1"
                xmlns:tfor="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeForest/types/2.0"
                xmlns:tforcon="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeForestConditions/types/2.0"
                xmlns:bon="http://rosleshoz.gov.ru/fgis-lk/common/enums/bonitet/types/2.1"
                xmlns:swt="http://rosleshoz.gov.ru/fgis-lk/common/enums/swampType/types/2.0"
                xmlns:tveget="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeVegetation/types/2.0"
                xmlns:slpst="http://rosleshoz.gov.ru/fgis-lk/common/enums/slopeSteepness/types/2.0"
                xmlns:slpexp="http://rosleshoz.gov.ru/fgis-lk/common/enums/slopeExposure/types/2.1"
                xmlns:erst="http://rosleshoz.gov.ru/fgis-lk/common/enums/erosionType/types/2.0"
                xmlns:ersdeg="http://rosleshoz.gov.ru/fgis-lk/common/enums/erosionDegree/types/2.0"
                xmlns:thaym="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeHaymaking/types/2.0"
                xmlns:conhaym="http://rosleshoz.gov.ru/fgis-lk/common/enums/conditionHaymaking/types/2.0"
                xmlns:qualhaym="http://rosleshoz.gov.ru/fgis-lk/common/enums/qualityHaymaking/types/2.0"
                xmlns:tgarpl="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeGardenPlants/types/2.0"
                xmlns:tree="http://rosleshoz.gov.ru/fgis-lk/common/enums/treeNew/types/2.0"
                xmlns:subspecies="http://rosleshoz.gov.ru/fgis-lk/common/enums/treeNew/types/2.1"
                xmlns:landt="http://rosleshoz.gov.ru/fgis-lk/common/enums/landType/types/2.1"
                xmlns:taxcat="http://rosleshoz.gov.ru/fgis-lk/common/enums/taxationCategory/types/2.0"
                xmlns:contl="http://rosleshoz.gov.ru/fgis-lk/common/enums/contaminationLands/types/2.0"
                xmlns:mclass="http://rosleshoz.gov.ru/fgis-lk/common/enums/marketabilityClass/types/2.1"
                xmlns:loct="http://rosleshoz.gov.ru/fgis-lk/common/enums/locationType/types/2.0"
                xmlns:gart="http://rosleshoz.gov.ru/fgis-lk/common/enums/gardenType/types/2.0"
                xmlns:complet="http://rosleshoz.gov.ru/fgis-lk/common/enums/completenesSlayer/types/2.1"
                xmlns:stfor="http://rosleshoz.gov.ru/fgis-lk/common/enums/stateForestPlant/types/2.0"
                xmlns:agecl="http://rosleshoz.gov.ru/fgis-lk/common/enums/ageClass/types/2.0"
                xmlns:seeds="http://rosleshoz.gov.ru/fgis-lk/common/enums/nameObjectSeedProd/types/2.0"
                xmlns:trust="http://rosleshoz.gov.ru/fgis-lk/common/enums/trustworthiness/types/2.0"
                xmlns:ozu="http://rosleshoz.gov.ru/fgis-lk/common/enums/nameProtectedForests/types/2.0"
                xmlns:purp="http://rosleshoz.gov.ru/fgis-lk/common/enums/purposeForests/types/2.1"
                xmlns:undrgrwth="http://rosleshoz.gov.ru/fgis-lk/common/enums/densityUndergrowth/types/2.0"
                xmlns:orig="http://rosleshoz.gov.ru/fgis-lk/common/enums/typeOrigin/types/2.0"
                xmlns:res="http://rosleshoz.gov.ru/fgis-lk/common/enums/forestResours/types/2.0"
                xmlns:rel="http://rosleshoz.gov.ru/fgis-lk/common/enums/relief/types/2.1"
                xmlns:coord="http://rosleshoz.gov.ru/fgis-lk/common/enums/coordinateSystem/types/2.1"
                xmlns:farm="http://rosleshoz.gov.ru/fgis-lk/common/enums/farms/types/2.1"
                xmlns:catroad="http://rosleshoz.gov.ru/fgis-lk/common/enums/purposeCreatedRoad/types/2.0"
                xmlns:season="http://rosleshoz.gov.ru/fgis-lk/common/enums/seasonUse/types/2.0"
                xmlns:extform="http://rosleshoz.gov.ru/fgis-lk/common/enums/geodataExternalFormat/types/2.0"
                xmlns:medetpo="http://rosleshoz.gov.ru/fgis-lk/common/enums/methodDeterminPoint/types/2.0"
                xmlns:spatprim="http://rosleshoz.gov.ru/fgis-lk/common/enums/spatialPrimitive/types/2.0"
                xmlns:okpd2="http://rosleshoz.gov.ru/fgis-lk/common/enums/okpd2/types/2.0"
                xmlns:usageType="http://rosleshoz.gov.ru/fgis-lk/common/enums/usageType/types/2.0"
                xmlns:tnved="http://rosleshoz.gov.ru/fgis-lk/common/enums/tnVed/types/2.0"
                xmlns:treeSub="http://rosleshoz.gov.ru/fgis-lk/common/enums/treeSubspecies/types/1.0"
                xmlns:fforest="http://rosleshoz.gov.ru/fgis-lk/common/enums/fellingForest/types/2.1"
                xmlns:cutgr="http://rosleshoz.gov.ru/fgis-lk/common/enums/cuttingGroupCategory/types/2.1"
                xmlns:ns1="http://rosleshoz.gov.ru/fgis-lk/common/enums/geodataStorage/types/2.0"
                xmlns:tns="http://rosleshoz.gov.ru/fgis-lk/common/enums/typesIdentityDoc/types/2.0"
                xmlns:dtype="http://rosleshoz.gov.ru/fgis-lk/common/enums/documentType/types/2.1"
                xmlns:dtypesell="http://rosleshoz.gov.ru/fgis-lk/common/enums/sellDocType/types/2.1"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xsi:schemaLocation="http://rosleshoz.gov.ru/fgis-lk/taxationDescription/types/2.0.0 ">

    <xsl:template match="/ns0:taxationDescription">
<html>
    <head>
        <style type="text/css">
            div.content {
            width: 1100px;
            margin: 5em auto;
            padding: 2em;
            background-color: #fdfdff;
            border-radius: 0.5em;
            box-shadow: 2px 3px 7px 2px rgba(0,0,0,0.02);
            font-family: "Open Sans", sans-serif;
            }
            .green-line {
            border: 1px solid #008000;
            border-radius: 100px;
            margin: 0;
            width: calc(100% - 9em);
            }
            h3 {
            padding-bottom: 20px;
            }
            h2 {
            text-align: center;
            padding-bottom: 20px;
            }
            .gray-line {
            border: 0,5px solid #000;
            border-radius: 100px;
            opacity: 0.4;
            margin: 10px;
            width: calc(100% - 9em);
            }
            .black-line{
            border: 5px solid #000;
            border-radius: 100px;
            margin: 10px;
            width: 1000px;
            }
            ul {
            list-style-type: none;
            }
            td {
            font-size: 14px;
            border: 1px solid #dddddd;
            width: 140px;
            text-align: center;
            }
            body {
            background-color: #f0f0f2;
            }
        </style>
    </head>
    <body>
        <div class="content">
            <h2>Общие сведения</h2>

            <!--line-->
            <hr class="green-line"/>
            <br/>
            <!--InfoDocument-->
            <h2>
                Сведения о документе
            </h2>
            <ul>
                <li>
                    <b>Наименование ОГВ/ОМС выпустившего документ: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:organizationName"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Наименование документа: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:documentName"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Номер документа: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:documentNumber"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Дата подготовки документа: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:documentData"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <br/>
            <!--sign-->
            <h2>Данные о подписанте</h2>

            <!--line-->
            <hr class="green-line"/>
            <br/>
            <h3>Данные сотрудника</h3>
            <ul>
            <li>
                <b>ФИО: </b>
                <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:sign/ns0:employee/ns0:fullName/cmplx:last"/>
                <xsl:text> </xsl:text>
                <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:sign/ns0:employee/ns0:fullName/cmplx:first"/>
            </li>
            <hr class="gray-line"/>

                <li>
                    <b>Должность: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:sign/ns0:employee/ns0:post"/>
                </li>
                <hr class="gray-line"/>

                <li>
                    <b>Наименование организации: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:sign/ns0:organization"/>
                </li>
                <hr class="gray-line"/>

                <li>
                    <b>Дата составления/подписания документа: </b>
                    <xsl:value-of select="ns0:header/ns0:infoDocument/ns0:sign/ns0:date"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>

            <!--infoBasic-->
            <h2>Основные сведения о выполняемых работах</h2>
            <!--line-->
            <hr class="green-line"/>
            <br/>
            <ul>
            <li>
                <b>Цель проведения работ: </b>
                <xsl:value-of select="ns0:header/ns0:infoBasic/ns0:objective"/>
            </li>
            <hr class="gray-line"/>
                <li>
                    <b>Наименование мероприятия: </b>
                    <xsl:value-of select="ns0:header/ns0:infoBasic/ns0:nameEvent"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <h3>Объект лесоустройства</h3>
                <li>
                    <b>Лесной участок: </b>
                    <xsl:value-of select="ns0:header/ns0:infoBasic/ns0:luObject/ns0:areasForest"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Дата начала мероприятий: </b>
                    <xsl:value-of select="ns0:header/ns0:infoBasic/ns0:dataStartEvent"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Дата окончания мероприятий: </b>
                    <xsl:value-of select="ns0:header/ns0:infoBasic/ns0:dataEndEvent"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <br/>

            <!--infoCustomer-->
            <h2>Сведения о заказчике</h2>
            <!--line-->
            <hr class="green-line"/>
            <br/>
            <h3>Сведения об индивидуальном предпринимателе</h3>
            <ul>
            <li>
                <b>ФИО: </b>
                <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:fio/cmplx:last"/>
                <xsl:text> </xsl:text>
                <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:fio/cmplx:first"/>
                <xsl:text> </xsl:text>
                <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:fio/cmplx:middle"/>
            </li>
            <hr class="gray-line"/>
            <li>
                <b>ИНН: </b>
                <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:inn"/>
            </li>
            <hr class="gray-line"/>
                <li>
                    <b>Дата регистрации: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:regDate"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Документ, удостоверяющий личность: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:iDocument"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>СНИЛС: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:snils"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <h3>
                    Почтовый адрес
                </h3>
                <li>
                    <b>ИНН: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:inn"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>ОКАТО: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:okato"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>КЛАДР: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:kladr"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Почтовый индекс: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:postalCode"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код региона: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:regioncode"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Район: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:district"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Муниципальное образование: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:city"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Городской район: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:urbanDistrict"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Сельхоз: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:sovietVillage"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Населенный пункт: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:locality"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Улица: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:street"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Дом: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:level1"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Корпус: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:level2"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Строение: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:level3"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Квартира: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:apartment"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Иное описание местоположения: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:individualEntrepreneur/ns0:location/ns0:note"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Номер телефона: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:telephone"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Иное описание местоположения: </b>
                    <xsl:value-of select="ns0:header/ns0:infoCustomer/ns0:email"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <br/>

            <!--infoPerformer-->
            <h2>Сведения об исполнителе работ</h2>
            <!--line-->
            <hr class="green-line"/>
            <br/>
            <ul>
                <li>
                    <b>Номер телефона: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:telephone"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Электронная почта: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:email"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <li>
                    <b>Сведения об организации исполнителя: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:name"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Дата регистрации: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:regDate"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>ИНН: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:inn"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>ОГРН: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:codeOGRN"/>
                </li>
                <hr class="gray-line"/>

                <h3>Почтовый адрес</h3>

                <li>
                    <b>Почтовый индекс: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:location/ns0:postalCode"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код региона: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:location/ns0:regioncode"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Район: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:location/ns0:district"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Муниципальное образование: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:location/ns0:city"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Улица: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:location/ns0:street"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Дом: </b>
                    <xsl:value-of select="ns0:header/ns0:infoPerformer/ns0:performer/ns0:infoOrganization/ns0:location/ns0:level1"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>


            <!--expert-->
            <h2>Сведения о сотрудниках, выполнивших работы</h2>
            <table>
                <tr>
                    <td>ФИО</td>
                    <td>Наименование организации</td>
                    <td>Номер в реестре специалистов</td>
                </tr>
                <xsl:for-each
                        select="ns0:header/ns0:infoPerformer/ns0:expert">
                    <tr>
                        <td>
                            <xsl:value-of select="ns0:FullName/cmplx:last"/>
                            <xsl:text> </xsl:text>
                            <xsl:value-of select="ns0:FullName/cmplx:first"/>
                            <xsl:text> </xsl:text>
                            <xsl:value-of select="ns0:FullName/cmplx:middle"/>
                        </td>
                        <td>
                            <xsl:value-of select="ns0:organization"/>
                        </td>
                        <td>
                            <xsl:value-of select="ns0:registrationNumber"/>
                        </td>
                    </tr>
                </xsl:for-each>
            </table>
            <!-- /header -->

            <!-- initialData -->
            <h2>Исходные данные</h2>
            <!--line-->
            <hr class="green-line"/>
            <br/>
            <ul>
                <xsl:for-each select="ns0:initialData/ns0:documents">
                    <li>
                        <b>Документы, использующиеся при проведении лесоустроительных работ: </b>
                        <xsl:value-of select="."/>
                    </li>
                    <hr class="gray-line"/>
                </xsl:for-each>
                <br/>
            </ul>
            <h2>Сведения о геодезической основе, использованной при проведении лесоустроительных работ</h2>
            <br/>
            <h3>
                Сведения о геодезической основе, использованной при проведении проектировании лесничества
            </h3>
            <ul>
                <li>
                    <b>Вид геодезической сети: </b>
                    <xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:tGeoNetwork"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Название пункта геодезической сети и тип знака: </b>
                    <xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:nameGeoNetworkPoint"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Система координат пункта геодезической сети: </b>
                    <xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:geoNetworkSystem"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <table>
                        <tr>
                            <td>Координата Х</td>
                            <td>Координата Y</td>
                            <td>Дата обследования</td>
                        </tr>
                        <tr>
                            <td><xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:xCoordinate"/></td>
                            <td><xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:yCoordinate"/></td>
                            <td><xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:dExaminate"/></td>
                        </tr>
                    </table>
                    <br/>
                    <br/>
                </li>
            </ul>

            <h3>Сведения о состоянии пункта геодезической сети</h3>
            <ul>
                <li>
                    <b>Сведения о состоянии наружного знака пункта: </b>
                    <xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:geoNetworkPointInfStatus/ns0:outPointSign"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Сведения о состоянии центра пункта: </b>
                    <xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:geoNetworkPointInfStatus/ns0:pointCenter"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Сведения о состоянии марки центра пункта: </b>
                    <xsl:value-of select="ns0:initialData/ns0:infoBase/ns0:infoGeodeticBase/ns0:geoNetworkPointInfStatus/ns0:pointCenterMarks"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <!-- infoMeasuring -->
            <h3>
                Сведения об измерениях</h3>
            <hr class="green-line"/>
            <br/>
            <table>
                <tr>
                    <td>Наименование прибора</td>
                    <td>Серийный номер устройства</td>
                    <td>Свидетельство о поверке</td>
                </tr>
                <xsl:for-each select="ns0:initialData/ns0:infoMeasuring/ns0:Device">
                    <tr>
                        <td>
                            <xsl:value-of select="ns0:nameDevice"/>
                        </td>
                        <td>
                            <xsl:value-of select="ns0:sNDevice"/>
                        </td>
                        <td>
                            <xsl:value-of select="ns0:infoCheckDevice"/>
                        </td>
                    </tr>
                </xsl:for-each>
            </table>
            <br/>
            <br/>

            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- characteristicsInfo -->
            <!-- ////////////////////////// -->
            <h3>Сведения о характеристиках лесотаксационных выделов</h3>
            <hr class="green-line"/>
            <br/>

            <xsl:for-each select="ns0:characteristicsInfo/ns0:forestQuarter">
                <h2>Информация о лесном квартале</h2>
                <br/>
                <h3>Характеристики лесного квартала</h3>
            <ul>

                <li>
                    <b>Лесничество: </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:forestryName/ns0:forestryName"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Учетный номер ФГИС ЛК лесничества: </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:forestryName/ns0:fgislkForestryNumber"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <li>
                    <b>Наименование участкового лесничества: </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:steadForestryName/ns0:steadForestryName"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Наименование урочища, лесной дачи, номер технического участка, иные сведения о подразделении до 01.01.2023 лесничеств, участковых лесничеств на составные части (при наличии): </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:nameTract"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Учетный номер ФГИС ЛК лесного квартала: </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:fgislkForestQuarterNumber"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Лесоустроительный номер лесного квартала: </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:luForestQuarterNumber"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Лесотаксационный разряд: </b>
                    <xsl:value-of select="ns0:characteristicsForestQuarter/ns0:taxationCategory"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <br/>


            <h3> Информация о содержимом лесного квартала</h3>
            <hr class="green-line"/>
            <br/>
            <h3>Информация о выделе</h3>
           <ul>
             <h3>Характеристики лесотаксационного выдела</h3>
               <br/>
               <li>
                   <b>Связи выдела с ОЗУЛ, КЗЛ, ВЛЦН:</b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:relations"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <!-- contoursLocation -->
                   <b>Описание границ лесотаксационного выдела</b>
                   <br/>
                   <ul>
                       <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:contoursLocation/contour:contours">
                           <li>
                               <xsl:value-of select="contour:contour/contour:entitySpatial"/>
                           </li>
                           <hr class="gray-line"/>
                       </xsl:for-each>
                   </ul>
               </li>
               <!-- currentAndPreviousNumbers -->
               <h3>Ранее присвоенные номера лесотаксационного выдела</h3>
               <li>
                   <b>Последний присвоенный номер: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:currentAndPreviousNumbers/ns0:currentNumberInfo/ns0:currentNumber"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Дата прекращения существования лесотаксационного выдела, в случае прекращения его существования: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:dateEndTaxationPiece"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Дата подготовки лесоустроительной документации: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:documentationDate"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Площадь: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:area/sfre:value"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Код справочника: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:area/sfre:unitMeasurement/sfre:code"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Единица измерения: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:area/sfre:unitMeasurement/sfre:value"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Погрешность: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:calcError"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Категория земель: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:categoryLand"/>
               </li>
               <hr class="gray-line"/>
               <br/>
               <br/>

               <h3>Общий запас лесных насаждений (при наличии)</h3>
               <br/>

               <li>
                   <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:totalStockForest/ns0:value"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:totalStockForest/ns0:unitMeasurement/ns0:code"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:totalStockForest/ns0:unitMeasurement/ns0:value"/>
               </li>
               <hr class="gray-line"/>
               <br/>
                        <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:registrationNumberCuttingArea">
               <li>
                   <b>Учетный номер лесосеки, расположенной в границе лесотаксационного выдела: </b>
                   <xsl:value-of select="."/>
               </li>
               <hr class="gray-line"/>
               </xsl:for-each>
               <li>
                   <b>Тип земель (лесные/нелесные): </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:typeLand"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Вид лесных земель: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:typeForestLand"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Вид нелесных земель: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:typeNonForestLand"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Тип леса: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:typeForest"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Тип лесорастительных условий: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:typeForestGrowingConditions"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Состояние лесного насаждения: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stateForestPlantation"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Целевая порода: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:targetSpecies"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Преобладающая порода: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:dominantSpecies"/>
               </li>
               <hr class="gray-line"/>
               <li>
                   <b>Класс бонитета: </b>
                   <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:bonusClass"/>
               </li>
               <hr class="gray-line"/>
           </ul>
            <br/>
            <br/>
            <h3>Запас на лесотаксационном выделе</h3>
            <hr class="green-line"/>
            <!-- deadWood -->
            <ul>
                <h3>Сухостоя</h3>
                <br/>
                <li>
                    <b>Значение: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:deadWood/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:deadWood/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:deadWood/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <!-- naturalRedines -->
                <h3>Естественных редин</h3>
                <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:naturalRedines/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:naturalRedines/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:naturalRedines/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <!-- singleTrees -->
                <h3>Единичных деревьев</h3>
                <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:singleTrees/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:singleTrees/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:singleTrees/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <!-- illiquidWood -->
                <h3>Неликвидной древесины</h3>
                <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:illiquidWood/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:illiquidWood/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:illiquidWood/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <!-- stockClutter -->
                <h3>Запас захламленности (м3 на 1 га)</h3>
                <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:stockClutter/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:stockClutter/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:stockClutter/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <!-- stockClutter -->
                <h3>Запас ликвида</h3>
                <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:liquidWood/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:liquidWood/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:stock/ns0:liquidWood/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>
            </ul>

            <ul>
            <li>
                <b>Год вырубки: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:year"/>
            </li>
            <hr class="gray-line"/>

            <li>
                <b>Хозяйственная секция: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:economSection"/>
            </li>
            <hr class="gray-line"/>
            <li>
                <b>Код возраста рубки: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:cutAge"/>
            </li>
            <hr class="gray-line"/>
                <br/>
        </ul>
            <h3>Сведения о ярусах лесного насаждения (для сомкнувшихся лесных насаждений)</h3>
            <hr class="green-line"/>
            <br/>

            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestPlantings">
                <h3>Сведения о ярусе лесного насаждения</h3>
                <li><b>Номер яруса: </b>
                    <xsl:value-of select="ns0:forestPlanting/ns0:number"/>
                </li>
                    <hr class="gray-line"/>
                    <li><b>Основной ярус, в случае, если ярус лесного насаждения является основным: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:mainTier"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Средняя высота</h3>
                    <br/>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageHeight/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageHeight/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageHeight/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>

                    <h3>Средний возраст</h3>
                    <br/>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageAge/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageAge/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageAge/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <br/>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>

                    <h3>Сумма площадей сечения стволов деревьев на высоте 1,3 метра на 1 гектар</h3>
                    <br/>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:sumAreasTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:sumAreasTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:sumAreasTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Состав лесного насаждения: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:compositionForestPlantation"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Полнота яруса: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:completenessLayer"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Запас древесины лесного насаждения</h3>
                    <br/>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:woodStockForestPlantings/ns0:averageStock/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:woodStockForestPlantings/ns0:averageStock/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:woodStockForestPlantings/ns0:averageStock/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h2>Сведения о древесных породах</h2>
                    <br/>
                    <h3>Сведения о породе</h3>
                    <ul>
                        <xsl:for-each select="ns0:forestPlanting/ns0:treeSpecies">

                            <li>
                                <b>Сведения о древесной или кустарниковой породе: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                            </li>
                            <hr class="gray-line"/>

                            <li>
                                <b>Доля участия породы в составе яруса лесного насаждения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                            </li>
                            <hr class="gray-line"/>

                            <h3>Возраст</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <li>
                                <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                            </li>
                            <hr class="gray-line"/>
                            <br/>

                            <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>
                            <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                            <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <li><b>Класс товарности: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <li><b>Происхождение насаждений: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <br/>
                        </xsl:for-each>
                        <!-- /treeSpecies -->
                    </ul>
                    <h2>Сведения о кустарниковых породах</h2>
                    <!-- shrubbySpecies -->
                    <ul>
                        <xsl:for-each select="ns0:forestPlanting/ns0:shrubbySpecies">
                            <h3>Сведения о породе</h3>
                            <li>
                                <b>Сведения о древесной или кустарниковой породе: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                            </li>
                            <hr class="gray-line"/>

                            <li>
                                <b>Доля участия породы в составе яруса лесного насаждения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                            </li>
                            <hr class="gray-line"/>

                            <h3>Возраст</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <li>
                                <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                            </li>
                            <hr class="gray-line"/>
                            <br/>

                            <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>
                            <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <li><b>Класс товарности: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                            <li>
                                <b>Значение: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Код справочника: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                            </li>
                            <hr class="gray-line"/>
                            <li>
                                <b>Единица измерения: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                            </li>
                            <br/>
                            <hr class="green-line"/>
                            <br/>

                            <li><b>Происхождение насаждений: </b>
                                <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                            <hr class="gray-line"/>
                            <br/>
                            <br/>
                        </xsl:for-each>
                        <li><b>
                            Является естественной рединой: </b>
                        <xsl:value-of select="ns0:forestPlanting/ns0:isNaturalPlain"/></li>
                        <hr class="gray-line"/>
                        <li><b>
                            Является естественным возобновлением: </b>
                            <xsl:value-of select="ns0:forestPlanting/ns0:naturalRenewal"/></li>
                        <hr class="gray-line"/>
                    </ul>
                    <hr class="green-line"/>
                </xsl:for-each>
            </ul>
            <!-- /ns0:forestPlantings -->
            <br/>
            <br/>
            <!-- nonClosedForestCrops -->
            <h2>Сведения о несомкнувшихся лесных культурах</h2>
            <ul>
                <li>
                    <b>Состав несомкнувшихся лесных культур: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:composition"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Способ подготовки почвы и производства лесных культур: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:soilPrepareMethod"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Приживаемость: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:survivalRate"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Количество высаженных деревьев, кустарников на одном гектаре: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:treeAmount"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Оценка качества высаженных деревьев, кустарников: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:treeQualityScore"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Причины неудовлетворительного состояния: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:poorStatusReason"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Причина гибели культуры (в случае гибели): </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:cropDeathReason"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <h3>Сведения о древесных породах</h3>
                <br/>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:treeSpecies">

                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>

                <!-- </ns0:treeSpecies> -->

                <!--  <ns0:shrubbySpecies> -->
            <!-- shrubbySpecies -->
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:shrubbySpecies">
                    <h3>Сведения о породе</h3>
                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
            </ul>
                <li><b>Тип несомкнувшихся культур (несомкнувшиеся лесные культуры на непокрытых лесной растительностью землях; несомкнувшиеся культуры под пологом леса; несомкнувшиеся культуры, созданные реконструкцией): </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:nonClosedForestType"/></li>
            <hr class="gray-line"/>

                <li><b>Дополнительные сведения (способ подготовки почвы и производства лесных культур, количество высаженных деревьев, кустарников на одном гектаре, оценка их качества, причины неудовлетворительного состояния, причина гибели культуры, в случае ее гибели): </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonClosedForestCrops/ns0:nonClosedForestType"/></li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <br/>
            <!-- </ns0:nonClosedForestCrops> -->


            <!-- treeUndergrowth -->
            <h2>Сведения о подросте</h2>
            <br/>
            <br/>
            <ul>
                <li><b>Состав: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:composition"/></li>
                <hr class="gray-line"/>
                <h3>Средняя высота</h3>
                <br/>

                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:averageHeight/ns0:value"/></li>
                <hr class="gray-line"/>

                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:averageHeight/ns0:unitMeasurement/ns0:code"/></li>
                <hr class="gray-line"/>

                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:averageHeight/ns0:unitMeasurement/ns0:value"/></li>
                <hr class="gray-line"/>
                <br/>

                <li><b>Оценка подроста: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:trustworthiness"/></li>
                <hr class="gray-line"/>
                <br/>
                <br/>
                <h3>Средний возраст</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:averageAge/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:averageAge/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:averageAge/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>

                <h3>Количество подроста на гектар</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:quantity/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:quantity/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:quantity/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
            </ul>

            <h2>Сведения о древесных породах</h2>
            <br/>
            <h3>Сведения о породе</h3>
            <ul>
            <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:treeSpecies">

                <li>
                    <b>Сведения о древесной или кустарниковой породе: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                </li>
                <hr class="gray-line"/>

                <li>
                    <b>Доля участия породы в составе яруса лесного насаждения: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                </li>
                <hr class="gray-line"/>

                <h3>Возраст</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>

                <li>
                    <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                </li>
                <hr class="gray-line"/>
                <br/>

                <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>

                <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>

                <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>
                <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                <hr class="gray-line"/>
                <br/>
                <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                <hr class="gray-line"/>
                <br/>
                <li><b>Класс товарности: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                <hr class="gray-line"/>
                <br/>
                <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>

                <li><b>Происхождение насаждений: </b>
                    <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                <hr class="gray-line"/>
                <br/>
                <br/>
            </xsl:for-each>
            </ul>
            <!-- /treeSpecies -->

            <!-- shrubbySpecies -->
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:shrubbySpecies">
                    <h3>Сведения о породе</h3>
                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
            </ul>

            <!-- forestUndergrowth -->
            <h2>Сведения о подросте</h2>
            <br/>
            <br/>
            <ul>
                <li><b>Состав: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestUndergrowth/ns0:composition"/></li>
                <hr class="gray-line"/>
                <h3>Средняя высота</h3>
                <br/>

                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestUndergrowth/ns0:averageHeight/ns0:value"/></li>
                <hr class="gray-line"/>

                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestUndergrowth/ns0:averageHeight/ns0:unitMeasurement/ns0:code"/></li>
                <hr class="gray-line"/>

                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestUndergrowth/ns0:averageHeight/ns0:unitMeasurement/ns0:value"/></li>
                <hr class="gray-line"/>
                <br/>

                <li><b>Густота подлеска: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestUndergrowth/ns0:densityUndergrowth"/></li>
                <hr class="gray-line"/>
                <br/>
                <br/>
            </ul>


            <h2>Сведения о древесных породах</h2>
            <br/>
            <h3>Сведения о породе</h3>
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestUndergrowth/ns0:treeSpecies">

                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
            </ul>
            <!-- /treeSpecies -->

            <!-- shrubbySpecies -->
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:treeUndergrowth/ns0:shrubbySpecies">
                    <h3>Сведения о породе</h3>
                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
            </ul>
            <br/>
            <br/>

            <!-- landsNotOccupiedForestPlantations -->
            <!-- treeSpecies -->
            <h2>Сведения в отношении не занятых лесными насаждениями земель</h2>
            <br/>
            <br/>
            <h2>Сведения о древесных породах</h2>
            <br/>
            <h3>Сведения о породе</h3>
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:treeSpecies">

                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
            </ul>
            <!-- /treeSpecies -->
            <!-- shrubbySpecies -->
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:treeUndergrowth/ns0:shrubbySpecies">
                    <h3>Сведения о породе</h3>
                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
            </ul>
            <br/>
            <br/>
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- characteristicsNaturalReforestation -->
            <!-- //////////////////////////////////////// -->
            <h2>Характеристика естественного лесовосстановления</h2>
            <h3>Средняя высота</h3>
            <ul>
                <li><b>Значение: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:averageHeight/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:averageHeight/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:averageHeight/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <h3>Средний возраст</h3>
            <ul>
                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:averageAge/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:averageAge/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:averageAge/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <h3>Количество подроста на гектар</h3>
            <ul>
                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:quantityTreeUndergrowth/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:quantityTreeUndergrowth/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:quantityTreeUndergrowth/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <br/>
                <li><b>Состав подроста: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsNotOccupiedForestPlantations/ns0:characteristicsNaturalReforestation/ns0:compositionTreeUndergrowth"/>
                </li>
                <hr class="gray-line"/>
            </ul>
            <br/>
            <br/>
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- </ns0:landsNotOccupiedForestPlantations> -->
            <!-- //////////////////////////////////////// -->


            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- deforestation -->
            <!-- //////////////////////////////////////// -->
            <h2>Сведения о вырубках</h2>
            <br/>
            <br/>
            <ul>
                <h3>Количество пней на 1 гектар вырубки</h3>
                <br/>
            <li><b>Значение: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:quantityStumps/ns0:value"/>
            </li>
            <hr class="gray-line"/>

            <li><b>Код справочника: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:quantityStumps/ns0:unitMeasurement/ns0:code"/>
            </li>
            <hr class="gray-line"/>
            <li><b>Единица измерения: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:quantityStumps/ns0:unitMeasurement/ns0:value"/>
            </li>
            <hr class="gray-line"/>
                <br/>
            </ul>

            <ul>
                <h3>В том числе пней сосны</h3>
                <br/>
                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:pineQuantityStumps/ns0:value"/>
                </li>
                <hr class="gray-line"/>

                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:pineQuantityStumps/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:pineQuantityStumps/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>
            </ul>

            <ul>
                <h3>Средний диаметр пней</h3>
                <br/>
                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:averageDiameterStumps/ns0:value"/>
                </li>
                <hr class="gray-line"/>

                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:averageDiameterStumps/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:averageDiameterStumps/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>
            </ul>

            <ul>
                <li><b>Тип вырубки: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:typeDeforestation"/>
                </li>
                <hr class="gray-line"/>

                <li><b>Год вырубки: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:deforestation/ns0:deforestationYear"/>
                </li>
                <hr class="gray-line"/>
                <br/>
            </ul>
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- /deforestation -->
            <!-- //////////////////////////////////////// -->




            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- singleTrees -->
            <!-- //////////////////////////////////////// -->
            <h2>Сведения о единичных деревьях</h2>
            <br/>
            <br/>
            <ul>
                <li><b>Состав: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:compositionSingleTrees"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <h3>Средний возраст</h3>
                <br/>

                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:averageAge/ns0:value"/>
                </li>
                <hr class="gray-line"/>

                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:averageAge/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:averageAge/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>
            </ul>

            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- treeSpecies -->
            <!-- ////////////////////////// -->
            <h2>Сведения о древесных породах</h2>
            <br/>
            <h3>Сведения о породе</h3>
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:treeSpecies">

                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>

                <h3>Средний запас древесины на 1 гектар</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:averageStockWood/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:averageStockWood/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:singleTrees/ns0:averageStockWood/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>
            </ul>
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- /treeSpecies -->
            <!-- ////////////////////////// -->
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- /singleTrees -->
            <!-- ////////////////////////// -->


            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- lostForestPlantations -->
            <!-- ////////////////////////// -->
            <h2>Сведения о погибших лесных насаждениях</h2>
            <br/>
            <br/>
            <ul>
                <li><b>Год гибели лесного насаждения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:year"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Тип повреждения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:typeDamage"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Вид лесного пожара: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:typeBurning"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Год повреждения лесного насаждения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:yearDamage"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Степень повреждения лесного насаждения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:degreeDamage"/>
                </li>
                <hr class="gray-line"/>
            </ul>

            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- treeSpecies -->
            <!-- ////////////////////////// -->
            <h2>Сведения о древесных породах</h2>
            <br/>
            <h3>Сведения о породе</h3>
            <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:treeSpecies">

                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /treeSpecies -->
                <!-- ////////////////////////// -->

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- weakenedStock -->
                <!-- ////////////////////////// -->
                <h3>Запас сильно ослабленных</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:weakenedStock/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:weakenedStock/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:weakenedStock/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>
                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /weakenedStock -->
                <!-- ////////////////////////// -->


                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- shrinkingStock -->
                <!-- ////////////////////////// -->
                <h3>Запас усыхающих</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:shrinkingStock/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:shrinkingStock/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:shrinkingStock/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <br/>
                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /shrinkingStock -->
                <!-- ////////////////////////// -->

                <li>
                    <b>Типы размещения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lostForestPlantations/ns0:typeAccom"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>
            </ul>
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- /lostForestPlantations -->
            <!-- ////////////////////////// -->

            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- haymaking -->
            <!-- ////////////////////////// -->
            <h2>Сведения о сенокосах (сельхозугодья (характеристика пашен, сенокосов, пастбищ, выгонов))</h2>
            <br/>
            <ul>
            <li>
                <b>Тип расположения сенокоса: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:typeHaymaking"/>
            </li>
            <br/>
            <hr class="gray-line"/>
                <li>
                    <b>Состояние сенокоса: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:conditionHaymaking"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <li>
                    <b>Качество сенокоса: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:qualityHaymaking"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <li>
                    <b>Естественные или улучшенные: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:naturalEnhanced"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <li>
                    <b>Степень зарастания древесными породами и кустарниками: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:degreeOvergrowth"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <li>
                    <b>Сведения о наличии кочек, камней и других факторов, влияющих на удобство заготовки сена: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:convenienceHayHarvesting"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <li>
                    <b>Сведения о возможности механизации работ: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:mechanizationWork"/>
                </li>
                <br/>
                <hr class="green-line"/>
            <br/>
            <br/>
                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- averageYield -->
                <!-- ////////////////////////// -->
                <h3>
                    Средняя урожайность сухой массы сена на 1 гектар
                </h3>
                <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:averageYield/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:averageYield/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:averageYield/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
                <hr class="green-line"/>
                <br/>
                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /averageYield -->
                <!-- ////////////////////////// -->
                <li>
                    <b>Сведения об эрозионных процессах: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:erosionProcesses"/>
                </li>
                <br/>
                <hr class="gray-line"/>
                <li>
                    <b>Порода: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:haymaking/ns0:speciesName"/>
                </li>
                <br/>
                <hr class="gray-line"/>
        </ul>

            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- /haymaking -->
            <!-- ////////////////////////// -->
            <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
            <!-- gardensVineyardsPlants -->
            <!-- ////////////////////////// -->
            <h2>Сведениях о садах, виноградниках, плодовых и ягодных растениях</h2>
                <br/>
                <br/>
            <ul>
                <li>
                <b>Плодоносящие или неплодоносящие: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:gardenType"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Тип (поливной/богарный): </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:typeIrrigationBogarny"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Год закладки: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:year"/>
                </li>
                <hr class="gray-line"/>
            </ul>
                <br/>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- quantityTrees -->
                <!-- ////////////////////////// -->
                <h3>Количество деревьев на 1 гектар</h3>
                <ul>
                <li><b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:quantityTrees/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:quantityTrees/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:quantityTrees/ns0:unitMeasurement/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <br/>
                <br/>
                </ul>


                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- yield -->
                <!-- ////////////////////////// -->

                <h3>Урожайность</h3>
                <ul>
                    <li><b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:yield/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li><b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:yield/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li><b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:yield/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </ul>
                <br/>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- treeSpecies -->
                <!-- ////////////////////////// -->
                <h2>Сведения о древесных породах</h2>
                <br/>
                <h3>Сведения о породе</h3>
                <ul>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:treeSpecies">

                    <li>
                        <b>Сведения о древесной или кустарниковой породе: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:name"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Доля участия породы в составе яруса лесного насаждения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:shareParticipation"/>
                    </li>
                    <hr class="gray-line"/>

                    <h3>Возраст</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:age/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li>
                        <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:predominantTreeSpecies"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>
                    <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:ageGroupForestPlantation"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <li><b>Класс товарности: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:marketabilityClass"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <br/>
                    <hr class="green-line"/>
                    <br/>

                    <li><b>Происхождение насаждений: </b>
                        <xsl:value-of select="ns0:speciesInfo/ns0:typeOrigin"/></li>
                    <hr class="gray-line"/>
                    <br/>
                    <br/>
                </xsl:for-each>
                    <br/>
                    <br/>
                </ul>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /treeSpecies -->
                <!-- ////////////////////////// -->

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- shrubbySpecies -->
                <!-- ////////////////////////// -->
                <h2>Сведения о кустарниковых породах</h2>
                <br/>
                <br/>
                <ul>
                    <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:gardensVineyardsPlants/ns0:shrubbySpecies/ns0:speciesInfo">
                        <h3>Сведения о породе</h3>
                        <li>
                            <b>Сведения о древесной или кустарниковой породе: </b>
                            <xsl:value-of select="ns0:name"/>
                        </li>
                        <hr class="gray-line"/>

                        <li>
                            <b>Доля участия породы в составе яруса лесного насаждения: </b>
                            <xsl:value-of select="ns0:shareParticipation"/>
                        </li>
                        <hr class="gray-line"/>

                        <h3>Возраст</h3>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:age/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:age/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:age/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <br/>
                        <hr class="green-line"/>
                        <br/>

                        <li>
                            <b>Преобладающая древесная порода (в случае, если порода является преобладающей): </b>
                            <xsl:value-of select="ns0:predominantTreeSpecies"/>
                        </li>
                        <hr class="gray-line"/>
                        <br/>

                        <h3>Высота в метрах с округлением до 1 метра (для древесной породы)</h3>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:heightTree/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:heightTree/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:heightTree/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <br/>
                        <hr class="green-line"/>
                        <br/>

                        <h3>Высота в метрах с округлением до 0,5 метра (для кустарниковой породы)</h3>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:heightShrub/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:heightShrub/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:heightShrub/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <br/>
                        <hr class="green-line"/>
                        <br/>

                        <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:averageDiameterBarrel/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:averageDiameterBarrel/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <br/>
                        <hr class="green-line"/>
                        <br/>
                        <li><b>Класс возраста преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                            <xsl:value-of select="ns0:ageClass"/></li>
                        <hr class="gray-line"/>
                        <br/>
                        <li><b>Группа возраста лесного насаждения для преобладающей породы (проставляется в случае, если порода является преобладающей): </b>
                            <xsl:value-of select="ns0:ageGroupForestPlantation"/></li>
                        <hr class="gray-line"/>
                        <br/>
                        <li><b>Класс товарности: </b>
                            <xsl:value-of select="ns0:marketabilityClass"/></li>
                        <hr class="gray-line"/>
                        <br/>
                        <h3>Средний диаметр ствола в сантиметрах с округлением до 1 сантиметра</h3>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:stockConstituentWoodSpecies/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:stockConstituentWoodSpecies/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <br/>
                        <hr class="green-line"/>
                        <br/>

                        <li><b>Происхождение насаждений: </b>
                            <xsl:value-of select="ns0:typeOrigin"/></li>
                        <hr class="gray-line"/>
                        <br/>
                        <br/>
                    </xsl:for-each>
                </ul>
                <br/>
                <br/>



                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- swamps -->
                <!-- ////////////////////////// -->

                <h2>Болота</h2>


                    <ul>
                    <li>
                    <b>Тип болота: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:swampType"/>
                </li>
                <hr class="gray-line"/>
                        <li>
                    <b>Тип растительности: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:typeVegetation"/>
                </li>
                <hr class="gray-line"/>
                        <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:thicknessLayer">
                            <h3>Толщина торфяного слоя</h3>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>
            </xsl:for-each>
                        <li>
                        <b>Порода: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:tree"/>
                    </li>
                <hr class="gray-line"/>
                        <h3>% зарастания</h3>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:perOvergrowth/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:perOvergrowth/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:swamps/ns0:perOvergrowth/ns0:unitMeasurement/ns0:value"/>
                        </li>
                </ul>
                <br/>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- positionForestTaxingAllocation -->
                <!-- ////////////////////////// -->

                <h2>
                    Сведения о положении лесотаксационного выдела
                </h2>
            <ul>
                    <li>
                     <b>Крутизна склона: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:slopeSteepness"/>
                    </li>
            <hr class="gray-line"/>
                    <li>
                    <b>Экспозиция склона: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:slopeExposure"/>
                    </li>
            <br/>

            <h3>Высота над уровнем моря</h3>
            <br/>
                <li>
                    <b>Значение: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:seaHeight/ns0:value"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Код справочника: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:seaHeight/ns0:unitMeasurement/ns0:code"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Единица измерения: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:seaHeight/ns0:unitMeasurement/ns0:value"/>
                </li>
                <br/>

                <li>
                    <b>Тип эрозии: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:typeErosion"/>
                </li>
                <li>
                    <b>Степень эрозии: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:positionForestTaxingAllocation/ns0:erosionDegree"/>
                </li>
            </ul>
                <br/>
                <br/>


                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /positionForestTaxingAllocation -->
                <!-- ////////////////////////// -->
            <ul>
                <li>
                    <b>Наименование объекта лесного семеноводства, созданного в границе лесотаксационного выдела: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nameObjectForestSeedProduction"/>
                </li>
                <hr class="gray-line"/>
                <li>
                    <b>Наименование объекта лесного семеноводства, созданного в границе лесотаксационного выдела: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:radionuclideContamination"/>
                </li>
                <hr class="gray-line"/>
            </ul>
                <br/>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- events -->
                <!-- ////////////////////////// -->

                <h2>Сведения о мероприятиях по сохранению лесов, проектируемых при осуществлении мероприятий по лесоустройству</h2>
                <br/>
                <br/>
                <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:events/ns0:event">
                <ul>
                    <li>
                        <b>Наименование проектируемого мероприятия в соответствии с нормативно-справочной информацией, указанной в п. 10 Порядка;</b>
                        <xsl:value-of select="ns0:eventName"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>
                    <h3>Объем проектируемого мероприятия в случае необходимости, единицы измерения проектируемому мероприятию в соответствии с нормативно-справочной информацией, указанной в п. 10 Порядка;</h3>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:projectEventVolume/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:projectEventVolume/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:projectEventVolume/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Номер РТК: </b>
                        <xsl:value-of select="ns0:rtk"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Иные сведения, том числе возможность использования неиспользуемых и неудобных для использования земель для лесоразведения, необходимость дополнительного специального обследования для оценки степени химической или радиационной загрязненности почв, прогноз неблагоприятных экзогенных геологических процессов): </b>
                        <xsl:value-of select="ns0:addInfo"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                </xsl:for-each>
                <br/>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /events -->
                <!-- ////////////////////////// -->
                <ul>
                    <li>
                        <b>Особо защитные участки: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:protectedForests"/>
                    </li>
                    <hr class="gray-line"/><li>
                        <b>Виды лесов по их целевому назначению: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:purposeForests"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Хозяйственная категория: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:farmCategory"/>
                    </li>
                    <hr class="gray-line"/><li>
                    <b>Рельеф: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:relief"/>
                </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Год последнего лесоустройства: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:lastManageYear"/>
                    </li>
                    <hr class="gray-line"/><li>
                    <b>Административный район: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:admRegion"/>
                </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Особенности выдела: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:peculiarities"/>
                    </li>
                    <hr class="gray-line"/>

                </ul>
                <br/>
                <br/>


                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- forestCrops -->
                <!-- ////////////////////////// -->


                <h2>Сведениях о лесных культурах</h2>
                <br/>

                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:year"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:cultivationMethod"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:creationMethod"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                    <br/>

                    <h3>Расстояние между рядами</h3>
                    <br/>
                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:distanceBetween/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:distanceBetween/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:distanceBetween/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <h3>Расстояние в ряду</h3>
                <br/>
                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:rowSpacing/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:rowSpacing/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:rowSpacing/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <h3>Количество посадочных мест на гектар</h3>
                <br/>
                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:quantity/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:quantity/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:quantity/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <ul>
                <li><b>Состояние лесных культур: </b>
                <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:state"/>
                </li>
                <hr class="gray-line"/>
                <li><b>Причины гибели: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:forestCrops/ns0:causesDeath"/>
                </li>
                <hr class="gray-line"/>
                </ul>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- landsLine -->
                <!-- ////////////////////////// -->
                <h3>Сведения о землях (объектах) линейного протяжения</h3>
                <br/>
                <ul>
                    <li>
                        <b>Вид дорог: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:typeRoad"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>
                        Ширина (метр)
                    </h3>

                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:width/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:width/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:width/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <h3>
                        Длина (метр)
                    </h3>

                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:length/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:length/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:length/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <ul>
                    <li>
                        <b>Состояние: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:state"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Назначение дороги: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:purpose"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Тип покрытия: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:typeCoating"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:roadwayWidth/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:roadwayWidth/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:roadwayWidth/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Сезонность действия: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:seasonality"/>
                    </li>
                    <hr class="gray-line"/>

                    <li>
                        <b>Требуются мероприятия: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landsLine/ns0:events"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /landsLine -->
                <!-- ////////////////////////// -->

            <ul>
                <li>
                    <b>Сведения о подсочке, осмолоподсочке (описание заподсоченных насаждений): </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:tapping"/>
                </li>
                <hr class="gray-line"/>

                <li>
                    <b>Рекреационная характеристика (ландшафтная характеристика) участков: </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:landscape"/>
                </li>
                <hr class="gray-line"/>
            </ul>
                <br/>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- soilCharacteristics -->
                <!-- ////////////////////////// -->

                <h3>Характеристика почвы</h3>
                <br/>
                <ul>
                    <li>
                        <b>Тип почвы: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:soilTypes"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Механический состав: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:mechanicalComp"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Степень влажности: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:humidityDegree"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Степень задернения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:turfingDegree"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Мощность гумусовых горизонтов: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:humusThickness"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/><br/>


                    <h3>Процент выхода на поверхность коренных горных пород</h3>

                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:perRocks/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:perRocks/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:soilCharacteristics/ns0:perRocks/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /soilCharacteristics -->
                <!-- ////////////////////////// -->


                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- schoolForest -->
                <!-- ////////////////////////// -->

                <h2>Питомники и лесные плантации</h2>
                <br/>

                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:year"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:cultivationMethod"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:creationMethod"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <h3>Расстояние между рядами</h3>
                <br/>
                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:distanceBetween/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:distanceBetween/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:distanceBetween/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <h3>Расстояние в ряду</h3>
                <br/>
                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:rowSpacing/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:rowSpacing/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:rowSpacing/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <h3>Количество посадочных мест на гектар</h3>
                <br/>
                <ul>
                    <li>
                        <b>Значение: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:quantity/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Код справочника: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:quantity/ns0:unitMeasurement/ns0:code"/>
                    </li>
                    <hr class="gray-line"/>
                    <li>
                        <b>Единица измерения: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:quantity/ns0:unitMeasurement/ns0:value"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <ul>
                    <li><b>Состояние лесных культур: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:state"/>
                    </li>
                    <hr class="gray-line"/>
                    <li><b>Причины гибели: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:schoolForest/ns0:causesDeath"/>
                    </li>
                    <hr class="gray-line"/>
                </ul>
                <br/>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /schoolForest -->
                <!-- ////////////////////////// -->

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- berries -->
                <!-- ////////////////////////// -->
                <h2>Сведения о травянистых растениях и ягодниках (описание редких растений, лекарственного сырья, ягодников, грибов)</h2>
                <br/>
                <ul>
                    <h3>Сведения о растении</h3>
                    <li>
                        <b>Категория учета: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:berries/ns0:categoryAccount"/>
                    </li>
                    <br/>
                    <hr class="gray-line"/>
                    <xsl:for-each select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:berries/ns0:berryType">

                        <li>
                            <b>Вид лек.трав, ягодников, грибов: </b>
                            <xsl:value-of select="ns0:forestResours"/>
                        </li>
                        <br/>
                        <hr class="gray-line"/>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:perCoating/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:perCoating/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:perCoating/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <br/>
                    </xsl:for-each>
                </ul>

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /berries -->
                <!-- ////////////////////////// -->

                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- nonWood -->
                <!-- ////////////////////////// -->
                <h2>Сведения о недревесном сырье (описание древесно-кустарниковых растений, техническое, лекарственное и пр. сырье)</h2>
                <br/>
                <ul>
                    <li>
                        <b>Категория сырья: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonWood/ns0:categoryRaw"/>
                    </li>
                    <br/>
                    <hr class="gray-line"/>
                    <h3>Единица объема</h3>
                    <br/>
                        <li>
                            <b>Значение: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonWood/ns0:unit/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Код справочника: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonWood/ns0:unit/ns0:unitMeasurement/ns0:code"/>
                        </li>
                        <hr class="gray-line"/>
                        <li>
                            <b>Единица измерения: </b>
                            <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonWood/ns0:unit/ns0:unitMeasurement/ns0:value"/>
                        </li>
                        <hr class="gray-line"/>
                        <br/>

                    <li>
                        <b>Урожайность: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonWood/ns0:yield"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>

                    <li>
                        <b>Признак доступности участка: </b>
                        <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:nonWood/ns0:availability"/>
                    </li>
                    <hr class="gray-line"/>
                    <br/>
                </ul>
                <br/>
                <br/>
                <!-- \\\\\\\\\\\\\\\\\\\\\\\\\\ -->
                <!-- /nonWood -->
                <!-- ////////////////////////// -->


                <ul>
                <li>
                    <b>Селекционная оценка (при селекционной инвентаризации): </b>
                    <xsl:value-of select="ns0:containForestQuarter/ns0:taxationPiece/ns0:characteristicsTaxationPiece/ns0:selection"/>
                </li>
                <hr class="gray-line"/>
                </ul>
                <br/>
                <hr class="black-line"/>
            </xsl:for-each>
        </div>
    </body>
</html>
</xsl:template>
</xsl:stylesheet>
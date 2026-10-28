Imports System.Data.Entity
Imports ArvandIntranetDomainClasses.Models
Imports ArvandIntranetDomainClasses.Models.Mapping
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.DomainClasses.Models.Mapping

Namespace Danesh.ArvandIntranet.DataLayer.Context

    Public Class ArvandIntranetContext
        Inherits DbContextBase
        Implements IUnitOfWork

        Public Property PHONEBOOK() As DbSet(Of Phonebook)
        Public Property ALBUMS() As DbSet(Of Album)
        Public Property ALBUMS_IMAGES() As DbSet(Of AlbumsImages)
        Public Property CITIES() As DbSet(Of City)
        Public Property COMPANIES() As DbSet(Of Company)
        Public Property COMPANY_TYPES() As DbSet(Of CompanyTypes)
        Public Property COMPLAINTS() As DbSet(Of Complaint)
        Public Property CONTACT_US() As DbSet(Of ContactUs)
        Public Property CONTACTS() As DbSet(Of Contact)
        Public Property COUNTRIES() As DbSet(Of Country)
        Public Property EXECUTIVE_MANAGERS() As DbSet(Of ExecutiveManagers)
        Public Property MASTERPAGE_WEBPARTS() As DbSet(Of MasterpageWebparts)
        Public Property MASTERPAGES() As DbSet(Of Masterpage)
        Public Property MENUS() As DbSet(Of Menu)
        Public Property NEWS() As DbSet(Of News)
        Public Property NEWS_GROUPS() As DbSet(Of NewsGroups)
        Public Property NEWS_KINDS() As DbSet(Of NewsKinds)
        Public Property NEWS_TYPES() As DbSet(Of NewsTypes)
        Public Property OPINIONS() As DbSet(Of Opinion)
        Public Property PAGES() As DbSet(Of Page)
        Public Property PAGES_METATAGS() As DbSet(Of PagesMetatags)
        Public Property PAGES_WEBPARTS() As DbSet(Of PageWebPart)
        Public Property PERSONNELs() As DbSet(Of Personnel)
        Public Property PLANT_DIVISIONS() As DbSet(Of PlantDivisions)
        Public Property POLLS() As DbSet(Of Poll)
        Public Property POLLS_ANSWERS() As DbSet(Of PollsAnswers)
        Public Property POLLS_FILLER() As DbSet(Of PollsFiller)
        Public Property POLLS_QUESTIONS() As DbSet(Of PollsQuestions)
        Public Property PRAYER_TIME() As DbSet(Of PrayerTime)
        Public Property PRODUCTS() As DbSet(Of Products)
        Public Property PROVINCES() As DbSet(Of Province)
        Public Property RESUMES() As DbSet(Of [Resume])
        Public Property SECURITY_FORMS() As DbSet(Of SecurityForms)
        Public Property SECURITY_FORMS_GRANTED() As DbSet(Of SecurityFormsGranted)
        Public Property SECURITY_SUBSYSTEMS() As DbSet(Of SecuritySubsystems)
        Public Property SECURITY_USERS() As DbSet(Of SecurityUsers)
        Public Property SITES_LINK() As DbSet(Of SitesLink)
        Public Property STATISTICS() As DbSet(Of Statistic)
        Public Property TENDERS() As DbSet(Of Tender)
        Public Property TENDERS_GROUPS() As DbSet(Of TendersGroups)
        Public Property TENDERS_TYPES() As DbSet(Of TendersTypes)
        Public Property VISITORS() As DbSet(Of Visitor)
        Public Property WEATHERs() As DbSet(Of Weather)
        Public Property WEBPARTS() As DbSet(Of Webpart)
        Public Property Theme() As DbSet(Of Theme)
        Public Property Software() As DbSet(Of Software)
        Public Property PageDesign() As DbSet(Of PageDesign)
        Public Property DocManagement() As DbSet(Of DocManagement)
        Public Property DocGrant() As DbSet(Of DocGrant)
        Public Property MaxVolume() As DbSet(Of MaxVolume)
        Public Property PollsQuestionsOptions() As DbSet(Of PollsQuestionsOptions)
        Public Property SystemHistory() As DbSet(Of SystemHistory)
        Public Property HouseCooperative() As DbSet(Of HouseCooperative)


        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)

            modelBuilder.Configurations.Add(New PhonebookMap())
            modelBuilder.Configurations.Add(New AlbumMap())
            modelBuilder.Configurations.Add(New AlbumsImagesMap())
            modelBuilder.Configurations.Add(New CityMap())
            modelBuilder.Configurations.Add(New CompanyMap())
            modelBuilder.Configurations.Add(New COMPANY_TYPESMap())
            modelBuilder.Configurations.Add(New COMPLAINTMap())
            modelBuilder.Configurations.Add(New CONTACT_USMap())
            modelBuilder.Configurations.Add(New CONTACTMap())
            modelBuilder.Configurations.Add(New COUNTRyMap())
            modelBuilder.Configurations.Add(New EXECUTIVE_MANAGERSMap())
            modelBuilder.Configurations.Add(New MASTERPAGE_WEBPARTSMap())
            modelBuilder.Configurations.Add(New MASTERPAGEMap())
            modelBuilder.Configurations.Add(New MenuMap())
            modelBuilder.Configurations.Add(New NewsMap())
            modelBuilder.Configurations.Add(New NewsGroupsMap())
            modelBuilder.Configurations.Add(New NewsKindsMap())
            modelBuilder.Configurations.Add(New NewsTypesMap())
            modelBuilder.Configurations.Add(New OPINIONMap())
            modelBuilder.Configurations.Add(New PageMap())
            modelBuilder.Configurations.Add(New PAGES_METATAGSMap())
            modelBuilder.Configurations.Add(New PAGES_WEBPARTSMap())
            modelBuilder.Configurations.Add(New PERSONNELMap())
            modelBuilder.Configurations.Add(New PlantDivisionsMap())
            modelBuilder.Configurations.Add(New POLLMap())
            modelBuilder.Configurations.Add(New PollsAnswersMap())
            modelBuilder.Configurations.Add(New PollsFillerMap())
            modelBuilder.Configurations.Add(New PollsQuestionsMap())
            modelBuilder.Configurations.Add(New PrayerTimeMap())
            modelBuilder.Configurations.Add(New ProductMap())
            modelBuilder.Configurations.Add(New PROVINCEMap())
            modelBuilder.Configurations.Add(New RESUMEMap())
            modelBuilder.Configurations.Add(New SecurityFormMap())
            modelBuilder.Configurations.Add(New SecurityFormGrantedMap())
            modelBuilder.Configurations.Add(New SECURITY_SUBSYSTEMSMap())
            modelBuilder.Configurations.Add(New SecurityUserMap())
            modelBuilder.Configurations.Add(New SitesLinkMap())
            modelBuilder.Configurations.Add(New STATISTICMap())
            modelBuilder.Configurations.Add(New TENDERMap())
            modelBuilder.Configurations.Add(New TENDERS_GROUPSMap())
            modelBuilder.Configurations.Add(New TENDERS_TYPESMap())
            modelBuilder.Configurations.Add(New VisitorMap())
            modelBuilder.Configurations.Add(New WEATHERMap())
            modelBuilder.Configurations.Add(New WEBPARTMap())
            modelBuilder.Configurations.Add(New ThemeMap())
            modelBuilder.Configurations.Add(New SoftwareMap())
            modelBuilder.Configurations.Add(New PAGES_DESIGNMap())
            modelBuilder.Configurations.Add(New DocManagementMap())
            modelBuilder.Configurations.Add(New DocGrantMap())
            modelBuilder.Configurations.Add(New MaxVolumeMap())
            modelBuilder.Configurations.Add(New PollsQuestionsOptionsMap())
            modelBuilder.Configurations.Add(New SystemHistoryMap())
            modelBuilder.Configurations.Add(New HouseCooperativeMap())

            MyBase.OnModelCreating(modelBuilder)
        End Sub

        Public Shadows Function [Set](Of TEntity As Class)() As IDbSet(Of TEntity) Implements IUnitOfWork.Set
            Return MyBase.Set(Of TEntity)()
        End Function

        Public Overrides Function SaveChanges() As Integer Implements IUnitOfWork.SaveChanges
            Return MyBase.SaveChanges()
        End Function

    End Class

End Namespace


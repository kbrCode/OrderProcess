Imports System.Runtime.Serialization

Partial Class AIMSDataContext
   Public Function AddToAims(ByVal Item As Item, ByVal Umsteller As String) As String
      Dim qryStdSystems = From stdsys As StdSystem In StdSystems Order By stdsys.Geraet
      Dim lstStdSystems As List(Of StdSystem) = qryStdSystems.ToList
      If Item.OrderItem.OrderableItem.AimsStdSystemsID Is Nothing Then
         Dim frmNewAIMSStdSystemMapping As New frmAIMSStdSystemMapping(Item, lstStdSystems)
         If frmNewAIMSStdSystemMapping.ShowDialog = Windows.Forms.DialogResult.OK Then
            Item.OrderItem.OrderableItem.AimsStdSystemsID = frmNewAIMSStdSystemMapping.StdSystemID
         Else
            Return Nothing
            Exit Function
         End If
      End If
      Dim comparer As New StdSystemPredicate(CInt(Item.OrderItem.OrderableItem.AimsStdSystemsID))
      Dim objStdSystem As StdSystem = lstStdSystems.Find(AddressOf comparer.CompareIDs)
      Dim intID As Integer = Nothing
      If objStdSystem.Typ = "G" Then 'Geraet (Desktop, Laptop, Smartphone)
         Dim tblGeraete As Table(Of Geraet) = Geraets
         If Item.AimsID Is Nothing Then
            Dim newGeraet As New Geraet()
            newGeraet.AdminWkst = objStdSystem.adminwkst
            newGeraet.Assettag = objStdSystem.assettag
            If Not (Item.AccountingUnit Is Nothing) Then
               newGeraet.Besitzer = Item.AccountingUnit.Besitzer
            Else
               newGeraet.Besitzer = "POOL"
            End If
            newGeraet.Best_Nr = Item.OrderItem.Order.EProcOrderNr
            newGeraet.BemerkungAllgemein = "Order-Nr: " & Item.OrderItem.Order.Nr
            newGeraet.Betriebssystem = objStdSystem.Betriebssystem
            newGeraet.CPU_Frequenz = objStdSystem.CPU_Frequenz
            newGeraet.CPU_Typ = objStdSystem.CPU_Typ
            newGeraet.Garantietyp = objStdSystem.Garantietyp
            newGeraet.Garantiezeit = objStdSystem.Garantiezeit
            newGeraet.Geraet = objStdSystem.Geraet
            newGeraet.Graphikkarte = objStdSystem.Graphikkarte
            newGeraet.HD_Disk = objStdSystem.HD_Disk
            newGeraet.Hersteller = objStdSystem.Hersteller
            newGeraet.Kategorie = objStdSystem.Kategorie
            If newGeraet.Kategorie = "Smartphone" Then
               Dim newMobilData As New MobilData
               newMobilData.Preis = Item.Price
               newMobilData.OriginalEditor = Umsteller
               newMobilData.Bemerkungen = Format(Now(), "d") & ": Gerät erfasst"
               newGeraet.MobilData = newMobilData
            End If
            newGeraet.Kauf_Date = Item.Delivery
            newGeraet.Lieferant = Item.OrderItem.Order.Supplier.ShortID
            newGeraet.Memory = objStdSystem.Memory
            newGeraet.Netzkarte = objStdSystem.Netzkarte
            newGeraet.Betriebssystem = objStdSystem.Betriebssystem
            newGeraet.Soundkarte = objStdSystem.Soundkarte
            newGeraet.Serie_Nr = Item.ItemID
            newGeraet.Status = 1
            newGeraet.Status_Date = Now()
            newGeraet.Typ_Nr = objStdSystem.Typ_Nr
            newGeraet.Umstelldatum = Now()
            newGeraet.Umsteller = Umsteller
            tblGeraete.InsertOnSubmit(newGeraet)
            Dim lstLastCHNr As List(Of LastCHNr) = LastCHNrs.ToList
            Dim LastCHNr = lstLastCHNr(0).LastCHNr
            newGeraet.CH_Nr = LastCHNr + 1
            SubmitChanges()
            ExecuteCommand("UPDATE dbo.LastCHNr SET LastCHNr = " & (LastCHNr + 1).ToString & " WHERE lastCHNr = " & LastCHNr)
            intID = newGeraet.ID
            Item.AimsID = "G-" & intID.ToString
         Else
            Dim arrAimsID As String() = Item.AimsID.Split("-")
            intID = CInt(arrAimsID(1))
            Dim qryGeraet = From ger In tblGeraete Where ger.ID = intID Select ger
            Dim lstGeraete As List(Of Geraet) = qryGeraet.ToList
            Dim Geraet As Geraet = lstGeraete(0)
            Geraet.Serie_Nr = Item.ItemID
            SubmitChanges()
         End If
         Return My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Geraet&trv2=" & intID.ToString
      ElseIf objStdSystem.Typ = "Z" Then 'Zubehör (Monitor, Dockingstation etc)
         Dim tblZubehoer As Table(Of Zubehoer) = Zubehoers
         If Item.AimsID Is Nothing Then
            Dim newZubehoer As New Zubehoer
            If Not (Item.AccountingUnit Is Nothing) Then
               newZubehoer.Besitzer = Item.AccountingUnit.ShortID
            Else
               newZubehoer.Besitzer = "POOL"
            End If
            newZubehoer.Best_Nr = Item.OrderItem.Order.EProcOrderNr
            newZubehoer.Garantietyp = objStdSystem.Garantietyp
            newZubehoer.Garantiezeit = objStdSystem.Garantiezeit
            newZubehoer.Geraet = objStdSystem.Geraet
            newZubehoer.Hersteller = objStdSystem.Hersteller
            newZubehoer.Kategorie = objStdSystem.Kategorie
            newZubehoer.Kauf_Date = Item.Delivery
            newZubehoer.Lieferant = Item.OrderItem.Order.Supplier.ShortID
            newZubehoer.Serie_Nr = Item.ItemID
            newZubehoer.Status = 1
            newZubehoer.Status_date = Now()
            newZubehoer.Typ_Nr = objStdSystem.Typ_Nr
            newZubehoer.Umsteller = Umsteller
            tblZubehoer.InsertOnSubmit(newZubehoer)
            SubmitChanges()
            intID = newZubehoer.ID
            Item.AimsID = "Z-" & intID.ToString
         Else
            Dim arrAimsID As String() = Item.AimsID.Split("-")
            intID = CInt(arrAimsID(1))
            Dim qryZubehoer = From zub In tblZubehoer Where zub.ID = intID Select zub
            Dim lstZubehoer As List(Of Zubehoer) = qryZubehoer.ToList
            Dim Zubehoer As Zubehoer = lstZubehoer(0)
            Zubehoer.Serie_Nr = Item.ItemID
            SubmitChanges()
         End If
         Return My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Zubehoer&trv2=" & intID.ToString
      ElseIf objStdSystem.Typ = "L" Then 'LAN-Printer
         Dim tblLANPrinter As Table(Of LANPrinter) = LANPrinters
         If Item.AimsID Is Nothing Then
            Dim newLANPrinter As New LANPrinter
            If Not (Item.AccountingUnit Is Nothing) Then
               newLANPrinter.Besitzer = Item.AccountingUnit.ShortID
            Else
               newLANPrinter.Besitzer = "POOL"
            End If
            newLANPrinter.Best_Nr = Item.OrderItem.Order.EProcOrderNr
            newLANPrinter.Typ = objStdSystem.Geraet
            newLANPrinter.Hersteller = objStdSystem.Hersteller
            newLANPrinter.RAM = objStdSystem.Memory
            newLANPrinter.dpi = objStdSystem.dpi
            newLANPrinter.Farbe = objStdSystem.farbe
            newLANPrinter.Optionen = objStdSystem.optionen
            newLANPrinter.Duplex = objStdSystem.duplex
            newLANPrinter.Comment = objStdSystem.comment
            newLANPrinter.Kauf_Date = Item.Delivery
            newLANPrinter.Lieferant = Item.OrderItem.Order.Supplier.ShortID
            newLANPrinter.Serie_Nr = Item.ItemID
            newLANPrinter.Inv_Nr = Item.ItemID
            newLANPrinter.Status = 1
            newLANPrinter.Status_date = Now()
            newLANPrinter.Umsteller = Umsteller
            tblLANPrinter.InsertOnSubmit(newLANPrinter)
            SubmitChanges()
            intID = newLANPrinter.ID
            Item.AimsID = "L-" & intID.ToString
         Else
            Dim arrAimsID As String() = Item.AimsID.Split("-")
            intID = CInt(arrAimsID(1))
            Dim qryLANPrinter = From lpr In tblLANPrinter Where lpr.ID = intID Select lpr
            Dim lstLANPrinter As List(Of LANPrinter) = qryLANPrinter.ToList
            Dim LANPrinter As LANPrinter = lstLANPrinter(0)
            LANPrinter.Serie_Nr = Item.ItemID
            SubmitChanges()
         End If
         Return My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=LAN-Printer&trv2=" & intID.ToString
      Else
         Return Nothing
      End If
    End Function
    Public Function UnAssignUser(ByVal AimsID As String, ByVal UserName As String, ByVal Besitzer As String) As String
        Dim firstSlash As Integer = UserName.IndexOf("/")
        Dim ShortUserName As String
        If firstSlash > 0 Then
            ShortUserName = UserName.Substring(0, firstSlash)
        Else
            ShortUserName = UserName
        End If
        Dim arrAimsID As String() = AimsID.Split("-")
        Dim tblBenutzer As Table(Of Benutzer) = Benutzers
        Dim qryBenutzer = From usr As Benutzer In tblBenutzer Where usr.Vorname & " " & usr.Name Like ShortUserName
        Dim lstBenutzer As List(Of Benutzer) = qryBenutzer.ToList
        Dim Benutzer As Benutzer = Nothing
        If lstBenutzer.Count > 0 Then
            Benutzer = lstBenutzer(0)
        End If
        If arrAimsID.Count = 2 AndAlso arrAimsID(0) = "G" Then
            Dim intAIMSID As Integer = CInt(arrAimsID(1))
            Dim tblGeraete As Table(Of Geraet) = Geraets
            Dim qryGeraet = From ger In tblGeraete Where ger.ID = intAIMSID Select ger
            Dim lstGeraete As List(Of Geraet) = qryGeraet.ToList
            If lstGeraete.Count = 0 Then
                Throw New MissingAIMSEntryException("AIMS-Entry " & AimsID & " missing. Operation aborted")
            End If
            Dim lstBesitzer As List(Of Besitzer) = Besitzers.ToList
            Dim lstKategorie As List(Of Kategorie) = Kategories.ToList
            Dim Geraet As Geraet = lstGeraete(0)
            Dim CHNR As Integer = Geraet.CH_Nr
            Dim tblGeraetBenutzer As Table(Of Geraet_Benutzer) = Geraet_Benutzers
            Dim qryGeraetBenutzer = From gb As Geraet_Benutzer In tblGeraetBenutzer Where gb.CH_Nr = CHNR
            Dim lstGeraetBenutzer As List(Of Geraet_Benutzer) = qryGeraetBenutzer.ToList
            If Benutzer IsNot Nothing Then
                If lstGeraetBenutzer.Count > 0 Then
                    For Each gb As Geraet_Benutzer In lstGeraetBenutzer
                        ExecuteCommand("DELETE FROM dbo.Geraet_Benutzer WHERE PersNr = " & gb.PersNr.ToString & " AND CH_Nr = " & CHNR.ToString)
                    Next
                End If
            End If

            If Geraet.Kategorie = "Smartphone" And Not Geraet.MobilData Is Nothing Then
                Geraet.MobilData.Kaufdatum = Nothing
                Geraet.MobilData.Bemerkungen = Nothing
            End If
        ElseIf arrAimsID.Count = 2 AndAlso arrAimsID(0) = "Z" Then
            Dim intAIMSID As Integer = CInt(arrAimsID(1))
            Dim tblZubehoer As Table(Of Zubehoer) = Zubehoers
            Dim qryZubehoer = From zub In tblZubehoer Where zub.ID = intAIMSID Select zub
            Dim lstZubehoer As List(Of Zubehoer) = qryZubehoer.ToList
            Dim Zubehoer As Zubehoer = lstZubehoer(0)
            Zubehoer.Besitzer = Nothing
            Zubehoer.Status = 1
            Zubehoer.Status_date = Nothing
            SubmitChanges()
        ElseIf arrAimsID.Count = 2 AndAlso arrAimsID(0) = "L" Then
            Dim intAIMSID As Integer = CInt(arrAimsID(1))
            Dim qryLANPrinter = From lpr In LANPrinters Where lpr.ID = intAIMSID Select lpr
            Dim lstLANPrinter As List(Of LANPrinter) = qryLANPrinter.ToList
            Dim LANPrinter As LANPrinter = lstLANPrinter(0)
            LANPrinter.Besitzer = Nothing
            LANPrinter.Verantwortlich = Nothing
            LANPrinter.Status = 1
            LANPrinter.Status_date = Nothing
            LANPrinter.PrinterName = Nothing
            SubmitChanges()
        End If
        Return Nothing
    End Function

    Public Function AssignUser(ByVal AimsID As String, ByVal UserName As String, ByVal Besitzer As String) As String
        Dim firstSlash As Integer = UserName.IndexOf("/")
        Dim ShortUserName As String
        If firstSlash > 0 Then
            ShortUserName = UserName.Substring(0, firstSlash)
        Else
            ShortUserName = UserName
        End If
        Dim arrAimsID As String() = AimsID.Split("-")
        Dim tblBenutzer As Table(Of Benutzer) = Benutzers
        Dim qryBenutzer = From usr As Benutzer In tblBenutzer Where usr.Vorname & " " & usr.Name Like ShortUserName
        Dim lstBenutzer As List(Of Benutzer) = qryBenutzer.ToList
        Dim Benutzer As Benutzer = Nothing
        If lstBenutzer.Count > 0 Then
            Benutzer = lstBenutzer(0)
        End If
        If arrAimsID.Count = 2 AndAlso arrAimsID(0) = "G" Then
            Dim intAIMSID As Integer = CInt(arrAimsID(1))
            Dim tblGeraete As Table(Of Geraet) = Geraets
            Dim qryGeraet = From ger In tblGeraete Where ger.ID = intAIMSID Select ger
            Dim lstGeraete As List(Of Geraet) = qryGeraet.ToList
            If lstGeraete.Count = 0 Then
                Throw New MissingAIMSEntryException("AIMS-Entry " & AimsID & " missing. Operation aborted")
            End If
            Dim lstBesitzer As List(Of Besitzer) = Besitzers.ToList
            Dim lstKategorie As List(Of Kategorie) = Kategories.ToList
            Dim Geraet As Geraet = lstGeraete(0)
            Dim CHNR As Integer = Geraet.CH_Nr
            Dim tblGeraetBenutzer As Table(Of Geraet_Benutzer) = Geraet_Benutzers
            Dim qryGeraetBenutzer = From gb As Geraet_Benutzer In tblGeraetBenutzer Where gb.CH_Nr = CHNR
            Dim lstGeraetBenutzer As List(Of Geraet_Benutzer) = qryGeraetBenutzer.ToList
            If Benutzer IsNot Nothing Then
                If lstGeraetBenutzer.Count > 0 Then
                    For Each gb As Geraet_Benutzer In lstGeraetBenutzer
                        ExecuteCommand("DELETE FROM dbo.Geraet_Benutzer WHERE PersNr = " & gb.PersNr.ToString & " AND CH_Nr = " & CHNR.ToString)
                    Next
                End If
                Dim newGB As New Geraet_Benutzer
                newGB.CH_Nr = CHNR
                newGB.PersNr = Benutzer.PersNr
                tblGeraetBenutzer.InsertOnSubmit(newGB)
                Geraet.Status = 3
                Geraet.Status_Date = Now()
                Geraet.Besitzer = Besitzer.Trim
                Dim searchBesitzer As New BesitzerPredicate(Geraet.Besitzer)
                Dim owner As Besitzer = lstBesitzer.Find(AddressOf searchBesitzer.CompareBezeichnung)
                Dim searchKategorie As New KategoriePredicate(Geraet.Kategorie, arrAimsID(0))
                Dim kategorie As Kategorie = lstKategorie.Find(AddressOf searchKategorie.CompareBezeichnung)
                If kategorie.LANDaten Then
                    Dim qryMaxNr = From HostName In MaxNummers
                    Dim lstMaxNr As List(Of MaxNummer) = qryMaxNr.ToList
                    Dim frmGeraeteNamen As New frmIDEntry(lstMaxNr)
                    frmGeraeteNamen.Text = "Enter Hostname"
                    If frmGeraeteNamen.ShowDialog = DialogResult.OK Then
                        Geraet.HostName = frmGeraeteNamen.RetVal
                    End If
                End If
                If Geraet.Kategorie = "Smartphone" And Not Geraet.MobilData Is Nothing Then
                    Geraet.MobilData.Kaufdatum = Now()
                    Geraet.MobilData.Bemerkungen = Geraet.MobilData.Bemerkungen & vbCrLf & Format(Now(), "d") & ": Gerät zugewiesen"
                End If
                'evaluate, whether anlagebuchhaltung is made and if yes, send mail to responsible person
                If owner.Anlagebuchhaltung AndAlso kategorie.AnlageBuchhaltung Then
                    Try
                        Dim Recipients As String() = owner.Email_AnlBuchh.Split(";")
                        Dim locMailClient As New SmtpClient("smtp.eu.schindler.com")
                        For Each recipient As String In Recipients
                            Dim locMailMessage As New MailMessage("orderprocess@donotreply.schindler.com", recipient)
                            locMailMessage.Subject = "Anlagebuchhaltungsnr für PC (CH-Nr: " & Geraet.CH_Nr & ") vergeben"
                            locMailMessage.Body = "PC (CH-Nr: " & Geraet.CH_Nr & ", Hostname: " & Geraet.HostName & ", Seriennummer: " & Geraet.Serie_Nr & ") neu im Wareneingang" & vbCrLf & _
                                                  "Link: " & My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Geraet&trv2=" & intAIMSID.ToString & vbCrLf & _
                                                  "Bitte in der Anlagenbuchhaltung erfassen"
                            locMailClient.Send(locMailMessage)
                        Next
                    Catch ex As SmtpException
                        MessageBox.Show("No Mail sent to " & owner.Email_AnlBuchh & ".", "Mail error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Else
                MessageBox.Show("User " & UserName & " not found in AIMS. Please assign manually.", "Unknown User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            SubmitChanges()
            Return My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Geraet&trv2=" & intAIMSID.ToString
        ElseIf arrAimsID.Count = 2 AndAlso arrAimsID(0) = "Z" Then
            Dim intAIMSID As Integer = CInt(arrAimsID(1))
            Dim tblZubehoer As Table(Of Zubehoer) = Zubehoers
            Dim qryZubehoer = From zub In tblZubehoer Where zub.ID = intAIMSID Select zub
            Dim lstZubehoer As List(Of Zubehoer) = qryZubehoer.ToList
            Dim Zubehoer As Zubehoer = lstZubehoer(0)
            Zubehoer.Besitzer = Besitzer.Trim
            Zubehoer.Status = 3
            Zubehoer.Status_date = Now()
            If Zubehoer.Inv_Nr Is Nothing Then
                Dim frmZubehoerInvNr As New frmIDEntry(Nothing)
                frmZubehoerInvNr.Text = "Enter Inv-Nr"
                If frmZubehoerInvNr.ShowDialog = DialogResult.OK Then
                    Zubehoer.Inv_Nr = frmZubehoerInvNr.RetVal
                End If
            End If
            SubmitChanges()
            If Benutzer IsNot Nothing Then
                Return My.Settings.AIMSurl & "aims.asp?trt=listusercomputer&trv1=Zubehoer&trv2=" & intAIMSID.ToString & "&trv3=" & Benutzer.Name & "%20" & Benutzer.Vorname
            Else
                MessageBox.Show("User " & UserName & " not found in AIMS. Please assign manually.", "Unknown User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=Zubehoer&trv2=" & intAIMSID.ToString
            End If
        ElseIf arrAimsID.Count = 2 AndAlso arrAimsID(0) = "L" Then
            Dim intAIMSID As Integer = CInt(arrAimsID(1))
            Dim qryLANPrinter = From lpr In LANPrinters Where lpr.ID = intAIMSID Select lpr
            Dim lstLANPrinter As List(Of LANPrinter) = qryLANPrinter.ToList
            Dim LANPrinter As LANPrinter = lstLANPrinter(0)
            LANPrinter.Besitzer = Besitzer.Trim
            LANPrinter.Verantwortlich = UserName
            LANPrinter.Status = 3
            LANPrinter.Status_date = Now
            Dim frmLANPrinterNamen As New frmIDEntry(Nothing)
            frmLANPrinterNamen.Text = "Enter LANPrinter Name"
            If frmLANPrinterNamen.ShowDialog = DialogResult.OK Then
                LANPrinter.PrinterName = frmLANPrinterNamen.RetVal
            End If
            SubmitChanges()
            Return My.Settings.AIMSurl & "aims.asp?trt=showitem&trv1=LAN-Printer&trv2=" & intAIMSID.ToString
        Else
            Return Nothing
        End If
    End Function
    Public Function FindInvNr(ByVal ZubehoerList As List(Of Zubehoer)) As InventoryNumbers
        Dim lstInvNr As New InventoryNumbers()
        Dim lstNewInvNr As New InventoryNumbers
        For Each zub As Zubehoer In ZubehoerList
            If zub.Inv_Nr IsNot Nothing Then
                lstInvNr.Add(New InventoryNumber(zub.Inv_Nr))
            End If
        Next
        For Each invnr As InventoryNumber In lstInvNr
            Dim findIndex As Integer = lstNewInvNr.FindType(invnr)
            If findIndex = -1 Then
                lstNewInvNr.Add(invnr)
            ElseIf invnr.Number > lstNewInvNr(findIndex).Number Then
                lstNewInvNr.InsertTo(invnr, findIndex)
            End If
        Next
        'do nothing
        Return lstNewInvNr
    End Function
End Class

Public Class StdSystemPredicate
   Private _ID As Integer
   Private _Geraet As String

   Public Sub New(ByVal ID As Integer)
      _ID = ID
   End Sub
   Public Sub New(ByVal Geraet As String)
      _Geraet = Geraet
   End Sub

   Public Function CompareIDs(ByVal obj As StdSystem) As Boolean
      Return (_ID = obj.ID)
   End Function
   Public Function CompareGeraet(ByVal obj As StdSystem) As Boolean
      Return (_Geraet = obj.Geraet)
   End Function
End Class

Public Class BesitzerPredicate
   Private _ID As Integer
   Private _Bezeichnung As String

   Public Sub New(ByVal ID As Integer)
      _ID = ID
   End Sub
   Public Sub New(ByVal Bezeichnung As String)
      _Bezeichnung = Bezeichnung
   End Sub

   Public Function CompareIDs(ByVal obj As Besitzer) As Boolean
      Return (_ID = obj.id)
   End Function
   Public Function CompareBezeichnung(ByVal obj As Besitzer) As Boolean
      Return (_Bezeichnung = obj.Bezeichnung)
   End Function
End Class

Public Class KategoriePredicate
   Private _ID As Integer
   Private _Bezeichnung As String
   Private _Typ As String

   Public Sub New(ByVal ID As Integer)
      _ID = ID
   End Sub
   Public Sub New(ByVal Bezeichnung As String, ByVal Typ As String)
      _Bezeichnung = Bezeichnung
      _Typ = Typ
   End Sub

   Public Function CompareIDs(ByVal obj As Kategorie) As Boolean
      Return (_ID = obj.ID)
   End Function
   Public Function CompareBezeichnung(ByVal obj As Kategorie) As Boolean
      Return (_Bezeichnung = obj.Bezeichnung) And (_Typ = obj.Typ)
   End Function
End Class

Public Class MissingAIMSEntryException
   Inherits ApplicationException
   Public Sub New()
      MyBase.New("This object has expired")
   End Sub
   Public Sub New(ByVal new_message As String)
      MyBase.New(new_message)
   End Sub
   Public Sub New(ByVal new_message As String, ByVal inner_exception As Exception)
      MyBase.New(new_message, inner_exception)
   End Sub
   Public Sub New(ByVal info As SerializationInfo, _
   ByVal context As StreamingContext)
      MyBase.New(info, context)
   End Sub
End Class

